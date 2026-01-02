using AIChat.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace AIChat.Views;

public partial class FirstView : ReactiveUserControl<FirstViewModel> {
    public FirstView() {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}