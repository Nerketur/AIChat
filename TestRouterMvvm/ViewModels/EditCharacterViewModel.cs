using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Models;

namespace TestRouterMvvm.ViewModels {
    public class EditCharacterViewModel : ViewModelBase {

        public static string DisplayName { get; } = "Edit Character";
        public string? UrlPathSegment { get; } = DisplayName;
        public EditCharacterViewModel() {
        }

    }
}
