using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables.Fluent;
using TestRouterMvvm.Models;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views;

public partial class CharacterControl : ReactiveUserControl<ViewModels.CharacterViewModel> {

    public static readonly StyledProperty<Models.Character> ModelProperty =
            AvaloniaProperty.Register<CharacterControl, Models.Character>(nameof(Model), defaultValue: new());
    public static readonly StyledProperty<string> DisplayNameProperty =
            AvaloniaProperty.Register<CharacterControl, string>(nameof(DisplayName), defaultValue: "Default");

    public Models.Character Model {
        get => GetValue(ModelProperty);
        set {
            SetValue(ModelProperty, value);
            if (ViewModel is not null)
                ViewModel.Model = value ?? new();
        }
    }
    public string DisplayName {
        get => GetValue(DisplayNameProperty);
        set {
            SetValue(ModelProperty, value);
        }
    }
    public CharacterControl() {

        ViewModel = new ViewModels.CharacterViewModel(null);

        this.WhenActivated(disposables => {
            ModelProperty.Changed.ObserveOn(RxApp.MainThreadScheduler).Subscribe(args => {
                if (ViewModel is not null)
                    ViewModel.Model = args.NewValue.GetValueOrDefault() ?? new();

            }).DisposeWith(disposables);
            this.WhenAnyValue(x => x.Model).ObserveOn(RxApp.MainThreadScheduler).Subscribe(model => {
                if (ViewModel is not null)
                    ViewModel.Model = model;
            }).DisposeWith(disposables);
            //CharacterImage.Source = "test.png";
        });
        AvaloniaXamlLoader.Load(this);
        //CharacterName.Text = "test";
    }

    private void UserControl_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        Model = ViewModel?.Model ?? new();
        //CharacterName.Text = DisplayName;
    }
}