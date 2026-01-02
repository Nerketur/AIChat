using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using ReactiveUI;
using ReactiveUI.Avalonia;
using TestRouterMvvm.Models;
using TestRouterMvvm.ViewModels;

using System;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Diagnostics;
using System.Linq;

namespace TestRouterMvvm;

public partial class CharacterChatView : ReactiveUserControl<CharacterChatViewModel> {
    public ComboBox? ScenarioComboBox => this.FindControl<ComboBox>("scenarioComboBox");

    public CharacterChatView() {

        this.WhenActivated(disposables => {
            this.ScenarioComboBox?
                .ObservableForProperty(cb => cb.SelectedItem).Prepend(null)
                //.Do(i => Debug.WriteLine(i.Value, "prop: "+i.Sender.ToString()))
                .Buffer(2, 1)
                //.Do(i => i.Select(item => {
                //    Debug.WriteLine(item?.Value, "buffer: " + item?.Sender.ToString());
                //    return i;
                //}).ToList())
                .Subscribe(
                    onNext: iList => {
                        if (iList.Count < 2) {
                            //Do nothing
                            return;
                        }
                        var prev = iList[0];
                        var curr = iList[1];
                        if (curr?.Value is ScenarioButton) {
                            this.ScenarioComboBox.SelectedItem = prev?.Value; // don't select it
                        }
                    }
                );
        });
        AvaloniaXamlLoader.Load(this);
        if (Design.IsDesignMode && Application.Current!.RequestedThemeVariant == ThemeVariant.Default) {
            Application.Current!.RequestedThemeVariant = ThemeVariant.Dark;
            //Brushes.
        }
    }

    private void TextBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e) {
        if (e.Key == Avalonia.Input.Key.Enter && ViewModel != null) {
            ViewModel.SendMessageCommand.Execute().ObserveOn(RxApp.MainThreadScheduler).Subscribe();
            e.Handled = true;
        }
    }
}