using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouting {
    public class FirstViewModel(IScreen screen) : ReactiveObject, IRoutableViewModel {
        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];

        public IScreen HostScreen => screen;
    }
}
