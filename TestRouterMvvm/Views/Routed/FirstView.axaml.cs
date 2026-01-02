using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views;

public partial class FirstView : ReactiveUserControl<FirstViewModel> {
    public FirstView() {
        //InitializeComponent();
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}