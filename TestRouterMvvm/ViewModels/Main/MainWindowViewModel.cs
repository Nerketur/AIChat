using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using TestRouterMvvm.Services;

namespace TestRouterMvvm.ViewModels {
    public class MainWindowViewModel : ViewModelBase, IScreen {

        public string Greeting => "Welcome to Avalonia!";

        /*
                    <TabStripItem>Home</TabStripItem>
                    <TabStripItem>Create Character</TabStripItem>
                    <TabStripItem>Manage Models</TabStripItem>
                    <TabStripItem>Settings</TabStripItem>
         
         */

        public List<MainTabsViewModel> MyTabs { get; } = [
            new() { Header = HomepageViewModel.DisplayName,        ViewModelFactory = (screen, fileDialogService) => new HomepageViewModel(screen) },
            new() { Header = CreateCharacterViewModel.DisplayName, ViewModelFactory = (screen, fileDialogService) => new CreateCharacterViewModel(screen) },
            new() { Header = ManageModelsViewModel.DisplayName,    ViewModelFactory = (screen, fileDialogService) => new ManageModelsViewModel(screen) },
            new() { Header = SettingsViewModel.DisplayName,        ViewModelFactory = (screen, fileDialogService) => new SettingsViewModel(screen, fileDialogService) }
        ];


        private MainTabsViewModel? _selectedTab = null;
        public MainTabsViewModel? SelectedTab {
            get => _selectedTab;
            set {
                this.RaiseAndSetIfChanged(ref _selectedTab, value);
                GoViewModel.Execute().Subscribe(x => { });
            }
        }

        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

        // The command that navigates a user to the selected Tab view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoViewModel { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, IRoutableViewModel> GoBack {
            get {
                return Router.NavigateBack; //.Do(rvm => SelectedTab = MyTabs.FirstOrDefault(tab => tab.Header == Router.NavigationStack[^2].UrlPathSegment));
            }
        }

        public MainWindowViewModel() {
            // Manage the routing state. Use the Router.Navigate.Execute
            // command to navigate to different view models. 
            //
            // Note, that the Navigate.Execute method accepts an instance 
            // of a view model, this allows you to pass parameters to 
            // your view models, or to reuse existing view models.
            //
            GoNext = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new FirstViewModel(this)).ObserveOn(RxApp.MainThreadScheduler)
            );
            GoViewModel = ReactiveCommand.CreateFromObservable(
                () => {
                    if (SelectedTab is not null) {
                        if (Router.NavigationStack.FirstOrDefault(vm => vm.UrlPathSegment?.StartsWith(SelectedTab.Header) ?? false) is IRoutableViewModel vm) {
                            Router.NavigationStack.Remove(vm);
                            return Router.Navigate.Execute(vm).ObserveOn(RxApp.MainThreadScheduler);
                        }
                        return Router.Navigate.Execute(SelectedTab.ViewModelFactory(this, new FileDialogService(Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null!))).ObserveOn(RxApp.MainThreadScheduler);
                    } else {
                        return Observable.Empty<IRoutableViewModel>();
                    }
                });

        }
    }
}
