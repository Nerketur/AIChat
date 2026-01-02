using ReactiveUI;
using System.Collections.Generic;
using System.Reactive;
using TestRouterMvvm.Models;

namespace TestRouterMvvm.ViewModels {
    public class CharacterViewModel(Character? _char) : ViewModelBase {
        private Character _model = _char ?? new();

        public Character Model {
            get => _model;
            set {
                this.RaiseAndSetIfChanged(ref _model, value);
                _lorebook = _model.Lorebook;
            }
        }

        private Dictionary<string, string?> _lorebook = _char?.Lorebook ?? [];

        public Dictionary<string, string?> LorebookEntries {
            get => _lorebook;
            set {
                this.RaiseAndSetIfChanged(ref _lorebook, value);
                Model.Lorebook = _lorebook;
            }
        }

        public ReactiveCommand<Unit, Unit> AddLorebookCommand
            => ReactiveCommand.Create(
                () => {
                    Model.Lorebook.Add("", "");
                    Model.Lorebook = new Dictionary<string, string?>(Model.Lorebook);
                    return Unit.Default;
                }
            );
    }
}
