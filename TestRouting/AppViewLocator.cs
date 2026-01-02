using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouting {
    public class AppViewLocator : ReactiveUI.IViewLocator {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) => viewModel switch {
            FirstViewModel context => new FirstView { DataContext = context },
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}
