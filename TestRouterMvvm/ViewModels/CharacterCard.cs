using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Models;

namespace TestRouterMvvm.ViewModels {
    public class CharacterCardViewModel : ViewModelBase {
        public int Id { get; set; }
        public required CharacterViewModel Character { get; set; }
        public required List<Scenario> Scenarios { get; set; }
    }
}
