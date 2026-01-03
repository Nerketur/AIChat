using ReactiveUI;
using System;
using TestRouterMvvm.Services;

namespace TestRouterMvvm.ViewModels {
    public class MainTabsViewModel {
        public string Header { get; set; } = "test tab " + Guid.NewGuid().ToString()[..5];

        public Func<IScreen, IFileDialogService, IRoutableViewModel> ViewModelFactory { get; set; } = (screen, _) => new FirstViewModel(screen);
    }
}
