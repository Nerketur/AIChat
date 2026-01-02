using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;
using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using TestRouterMvvm.ViewModels;
using TestRouterMvvm.Views;

namespace TestRouterMvvm {
    public partial class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDeveloperTools();
#endif
            RxApp.DefaultExceptionHandler = new MyCoolObservableExceptionHandler();
        }

        public override void OnFrameworkInitializationCompleted() {
            // Register all the services needed for the application to run
            //var collection = new ServiceCollection();
            //collection.AddCommonServices();


            //// Creates a ServiceProvider containing services from the provided IServiceCollection
            //var services = collection.BuildServiceProvider();


            //var vm = services.GetRequiredService<MainWindowViewModel>();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow = new MainWindow {
                    DataContext = Locator.Current.GetService<MainWindowViewModel>(),
                };
            }
            base.OnFrameworkInitializationCompleted();
        }

    }
    public class MyCoolObservableExceptionHandler : IObserver<Exception> {
        public void OnNext(Exception value) {
            if (Debugger.IsAttached) Debugger.Break();

            //Analytics.Current.TrackEvent("MyRxHandler", new Dictionary<string, string>()
            //                                        {
            //                                        {"Type", value.GetType().ToString()},
            //                                        {"Message", value.Message},
            //                                    });

            RxApp.MainThreadScheduler.Schedule(() => { throw value; });
        }

        public void OnError(Exception error) {
            if (Debugger.IsAttached) Debugger.Break();

            //Analytics.Current.TrackEvent("MyRxHandler Error", new Dictionary<string, string>() {
            //    {"Type", error.GetType().ToString()},
            //    {"Message", error.Message},
            //});

            RxApp.MainThreadScheduler.Schedule(() => { throw error; });
        }

        public void OnCompleted() {
            if (Debugger.IsAttached) Debugger.Break();
            RxApp.MainThreadScheduler.Schedule(() => { throw new NotImplementedException(); });
        }
    }
}