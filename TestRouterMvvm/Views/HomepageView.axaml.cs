using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views;

public partial class HomepageView : ReactiveUserControl<HomepageViewModel> {
    public HomepageView() {
        //ViewModel = new HomepageViewModel();
        this.WhenActivated(disposables => {
        });
        AvaloniaXamlLoader.Load(this);
    }

    private void StackPanel_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) {
        if (e.Source is StyledElement i && i.DataContext is CharacterCardViewModel cc) {
            //needs to be on UI thread
            ViewModel?.HostScreen.Router.Navigate.Execute(new CharacterChatViewModel(ViewModel.HostScreen, cc.Character, cc.Scenarios, 0)).ObserveOn(RxApp.MainThreadScheduler).Subscribe(obv => { });
        }
        Debug.WriteLine(e.Source);
    }
}