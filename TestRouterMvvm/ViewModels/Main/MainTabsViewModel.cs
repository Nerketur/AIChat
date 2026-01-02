using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Services;

namespace TestRouterMvvm.ViewModels {
    public class MainTabsViewModel {
        public string Header { get; set; } = "test tab " + Guid.NewGuid().ToString()[..5];

        public Func<IScreen, IFileDialogService, IRoutableViewModel> ViewModelFactory { get; set; } = (screen, _) => new FirstViewModel(screen);
    }
}
