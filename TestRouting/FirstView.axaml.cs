using ReactiveUI;
using ReactiveUI.Avalonia;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TestRouting;

public partial class FirstView : ReactiveUserControl<FirstViewModel> {
    public FirstView() {
        InitializeComponent();
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}