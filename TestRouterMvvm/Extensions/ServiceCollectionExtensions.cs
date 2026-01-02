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
using TestRouterMvvm.Views.Settings;

namespace TestRouterMvvm.Extensions {
    public static class ServiceCollectionExtensions {
        public static void AddCommonServices(this IServiceCollection collection) {
            //collection.AddSingleton<IRepository, Repository>();
            //collection.AddScoped<IFileDialogService>((sp) => new FileDialogService());
            collection.AddTransient<MainWindowViewModel>();
            collection.AddSingleton<HomepageView>();
            collection.AddTransient<HomepageViewModel>();
            collection.AddSingleton<ImportExportSettingsView>();
            collection.AddTransient<ImportExportSettingsViewModel>();
            collection.AddSingleton<SettingsView>();
            collection.AddSingleton<SettingsViewModel>();
            collection.AddSingleton<SettingsTabsViewModel>();
            collection.AddSingleton<IViewLocator>((sp) => new AppViewLocator(sp));
            collection.AddSingleton<IFileDialogService, FileDialogService>();
            collection.AddSingleton<TopLevel, MainWindow>();

            //collection.AddSingleton<ViewLocator>((sp) => new ViewLocator(sp.GetRequiredService<MainWindow>()));
        }
    }
}
