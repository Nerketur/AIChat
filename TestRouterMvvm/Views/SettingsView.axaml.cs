using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views;

public partial class SettingsView : ReactiveUserControl<SettingsViewModel> {
    public SettingsView() {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}