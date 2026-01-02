using Avalonia; // AppBuilder
using ReactiveUI.Avalonia; // UseReactiveUI, RegisterReactiveUIViews* (core)
using ReactiveUI.Avalonia.Splat; // Autofac, DryIoc, Ninject, Microsoft.Extensions.DependencyInjection integrations
using System;
using TestRouterMvvm.Extensions;

namespace TestRouterMvvm {
    internal sealed class Program {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .UseReactiveUIWithMicrosoftDependencyResolver(
                    services => {
                        services.AddCommonServices();
                        // services.AddSingleton<MainViewModel>();
                    },
                    withResolver: sp => {
                        // Optional: access ServiceProvider
                    })
                ;
    }
}
