using Avalonia.Threading;
using ReactiveUI;
using System;
using TestRouterMvvm.ViewModels;
using TestRouterMvvm.Views;
using TestRouterMvvm.Views.Routed;

namespace TestRouterMvvm {
    public class AppViewLocator(IServiceProvider _sp) : ReactiveUI.IViewLocator {

        public IServiceProvider ServiceProvider { get; set; } = _sp;

        // use simple caching
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) {
            return viewModel switch {
                FirstViewModel context => new FirstView { DataContext = context },
                HomepageViewModel context => new HomepageView { DataContext = context },
                CreateCharacterViewModel context => new CreateCharacterView { DataContext = context },
                ManageModelsViewModel context => new ManageModelsView { DataContext = context },
                SettingsViewModel context => new SettingsView { DataContext = context },
                CharacterChatViewModel context => new CharacterChatView { DataContext = context },
                _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
            };
        }
    }
}
