using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views.Routed;

public partial class CreateCharacterView : ReactiveUserControl<CreateCharacterViewModel> {
    public CreateCharacterView() {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}