using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using TestRouterMvvm.Models.Database;

namespace TestRouterMvvm.Models {
    public class UserPersona {
        public static UserPersona Default { get; set; } = new() {
            Name = "Flor",
            Persona = "Flor is a human with a Crescent on her forehead."
        };

        public int Id { get; set; }
        public required string Name { get; set; }
        public string FormattedPersona => Persona.Replace("{user}", Name);
        public string Persona { get; set; } = "";
        public IImage Image { get; set; } = new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/36e6f1f77a7a15b3d1b1fef2cf1b6ff7.jpg")));

        internal DBUserPersona ToDatabaseModel() {
            return new DBUserPersona {
                Name = this.Name,
                Persona = this.Persona,
                // DBScenarios = this.Scenarios.Select(s => s.ToDatabaseModel()).ToList()
            };
        }
    }
}
