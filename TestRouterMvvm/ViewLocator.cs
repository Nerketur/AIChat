using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using TestRouterMvvm.Services;
using TestRouterMvvm.ViewModels;
using TestRouterMvvm.ViewModels.Settings;
using TestRouterMvvm.Views;
using TestRouterMvvm.Views.Settings;

namespace TestRouterMvvm {
    /// <summary>
    /// Given a view model, returns the corresponding view if possible.
    /// </summary>
    [RequiresUnreferencedCode(
        "Default implementation of ViewLocator involves reflection which may be trimmed away.",
        Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
    public class ViewLocator(MainWindow _mw) : IDataTemplate {
        public MainWindow MainWindow { get; set; } = _mw;

        public Control? Build(object? param) {

            
            switch (param) {
                case ImportExportSettingsViewModel viewModel:
                    return new ImportExportSettingsView() { DataContext = viewModel };
                case null:
                    return null;
            }

            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null) {
                if (type.GetConstructor(Type.EmptyTypes) is ConstructorInfo)
                    return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data) {
            return data is ViewModelBase;
        }
    }
}
