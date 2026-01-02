using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Models;

namespace TestRouterMvvm.ViewModels {
    public class HomepageViewModel(IScreen? screen) : ViewModelBase, IRoutableViewModel {

        // Parameterless constructor for design-time support
        public HomepageViewModel() : this(null) { }

        public static string DisplayName { get; } = "Home";

        public List<CharacterCardViewModel> CharacterList {
            get => CharacterService.AllCharacterCards;
            set => this.RaiseAndSetIfChanged(ref CharacterService.AllCharacterCards, value);
        }

        public CharacterCardViewModel WantedModel { get; set; } = new() {
            Character = new(new() {
                DisplayName = "Example Character",
                Name = "ExampleName",
                Author = "AuthorName",
                Persona = "This is an example persona.",
                ImagePath = new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/example.png"))),
                IsMature = false,
                Lorebook = new Dictionary<string, string?> {
                    { "Background", "This is the background lore of the example character." },
                    { "Abilities", "These are the abilities of the example character." }
                }
            }),
            Scenarios = [new()]
        };

        public string? UrlPathSegment { get; } = DisplayName;

        public IScreen HostScreen => screen!;

    }
}
