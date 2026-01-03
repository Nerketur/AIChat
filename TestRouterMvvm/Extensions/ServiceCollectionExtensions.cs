using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Services;
using TestRouterMvvm.ViewModels;
using TestRouterMvvm.ViewModels.Settings;
using TestRouterMvvm.Views;
using TestRouterMvvm.Views.Routed;
using TestRouterMvvm.Views.Settings;

namespace TestRouterMvvm.Extensions {
    public static class ServiceCollectionExtensions {
        public static void AddCommonServices(this IServiceCollection collection) {
            collection.AddTransient<MainWindowViewModel>();
            collection.AddTransient<HomepageViewModel>();
            collection.AddTransient<ImportExportSettingsViewModel>();
            collection.AddSingleton<SettingsViewModel>();
            collection.AddSingleton<SettingsTabsViewModel>();
            collection.AddSingleton<IViewLocator>((sp) => new AppViewLocator(sp));
            collection.AddSingleton<IFileDialogService, FileDialogService>();
            collection.AddSingleton<TopLevel, MainWindow>();

            //collection.AddSingleton<ViewLocator>((sp) => new ViewLocator(sp.GetRequiredService<MainWindow>()));
        }
    }
}
