using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouterMvvm.ViewModels {
    public class ManageModelsViewModel(IScreen screen) : ViewModelBase, IRoutableViewModel {
        public static string DisplayName { get; } = "Manage Models";
        public string? UrlPathSegment { get; } = DisplayName;

        public IScreen HostScreen => screen;

    }
}
