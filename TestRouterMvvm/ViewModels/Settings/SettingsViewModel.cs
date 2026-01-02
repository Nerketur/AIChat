using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Services;
using TestRouterMvvm.ViewModels.Settings;

namespace TestRouterMvvm.ViewModels {
    public class SettingsViewModel(IScreen screen, IFileDialogService fileDialogService) : ViewModelBase, IRoutableViewModel {

        // Parameterless constructor for design-time support
        public SettingsViewModel() : this(null!, null!) { }

        public static string DisplayName { get; } = "Settings";
        
        public string? IconSource => "avares://TestRouterMvvm/Assets/Icons/settings-24px.svg";

        private SettingsTabsViewModel? _selectedTab = null;
        public SettingsTabsViewModel? SelectedTab {
            get => _selectedTab;
            set => this.RaiseAndSetIfChanged(ref _selectedTab, value);
        }

        public SettingsTabsViewModel[] MyTabs { get; } = [
            new() { Header = GeneralSettingsViewModel.DisplayName,      ViewModel = new GeneralSettingsViewModel() },
            new() { Header = AdvancedSettingsViewModel.DisplayName,     ViewModel = new AdvancedSettingsViewModel() },
            new() { Header = ImportExportSettingsViewModel.DisplayName, ViewModel = new ImportExportSettingsViewModel(fileDialogService) },
        ];

        public ImportExportSettingsViewModel Tab1VM => Dispatcher.UIThread.Invoke<ImportExportSettingsViewModel>(() => new(fileDialogService));
        public AdvancedSettingsViewModel Tab2VM => new();
        internal GeneralSettingsViewModel Tab3VM => new();

        public string? UrlPathSegment { get; } = DisplayName;
        public IScreen HostScreen => screen;

    }
}
