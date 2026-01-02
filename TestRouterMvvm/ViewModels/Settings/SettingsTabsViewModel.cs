using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.ViewModels.Settings;

namespace TestRouterMvvm.ViewModels {
    public class SettingsTabsViewModel {
        public string Header { get; set; } = "test tab " + Guid.NewGuid().ToString()[..5];

        public ViewModelBase ViewModel { get; set; } = new GeneralSettingsViewModel();
    }
}
