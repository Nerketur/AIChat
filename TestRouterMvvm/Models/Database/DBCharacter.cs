using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouterMvvm.Models.Database {
    internal class DBCharacter {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DisplayName { get; set; } = "New Character Display Name";
        public string Name { get; set; } = "New Character";
        [NotMapped]
        public IImage? ImagePath { get; set; } = new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/example.png")));
        public string Author { get; set; } = "Unknown";
        public string FormattedPersona => Persona.Replace("{character}", Name);
        public string Persona { get; set; } = "No Persona";
        public List<EFKeyValuePair<string, string?>> Lorebook { get; set; } = [];
        public bool IsMature { get; set; } = false;
        public List<DBScenario> Chats { get; set; } = [];
    }
}
