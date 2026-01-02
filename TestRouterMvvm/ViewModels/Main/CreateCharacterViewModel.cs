using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouterMvvm.ViewModels {
    public class CreateCharacterViewModel(IScreen screen) : ViewModelBase, IRoutableViewModel {
        public static string DisplayName { get; } = "Create Character";
        public string? UrlPathSegment { get; } = DisplayName;

        public IScreen HostScreen => screen;

    }
}
