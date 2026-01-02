using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;

using System;
using System.Reactive.Disposables.Fluent;
using TestRouterMvvm.Models;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views;

public partial class EditCharacterView : ReactiveUserControl<EditCharacterViewModel> {

    public static readonly StyledProperty<CharacterViewModel> CharacterProperty =
        AvaloniaProperty.Register<CharacterControl, CharacterViewModel>(nameof(Character), defaultValue: new(null));

    public CharacterViewModel Character {
        get => GetValue(CharacterProperty);
        set {
            SetValue(CharacterProperty, value);
        }
    }

    public EditCharacterView() {
        this.WhenActivated(disposables => {

        });
        AvaloniaXamlLoader.Load(this);
    }
}