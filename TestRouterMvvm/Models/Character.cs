using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace TestRouterMvvm.Models {
    public class Character {

        public string DisplayName { get; set; } = "New Character Display Name";
        public string Name { get; set; } = "New Character";
        public IImage? ImagePath { get; set; } = new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/example.png")));
        public string Author { get; set; } = "Unknown";
        public string FormattedPersona => Persona.Replace("{character}", Name);
        public string Persona { get; set; } = "No Persona";
        public Dictionary<string, string?> Lorebook { get ; set; } = new() { { "test", "test2" } };
        public bool IsMature { get; set; } = false;
        public List<Scenario> Chats { get; set; } = [new()];
    }
}
