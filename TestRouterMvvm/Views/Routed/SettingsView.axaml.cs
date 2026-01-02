using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views.Routed;

public partial class SettingsView : ReactiveUserControl<SettingsViewModel> {
    public SettingsView() {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}