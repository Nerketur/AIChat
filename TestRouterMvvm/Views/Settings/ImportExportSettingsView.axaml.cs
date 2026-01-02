using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using ReactiveUI.Avalonia;
using SkiaSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestRouterMvvm.Models;
using TestRouterMvvm.Models.BYAFRelated;
using TestRouterMvvm.Models.ChatMessages;
using TestRouterMvvm.Models.JsonPOJOs;
using TestRouterMvvm.Services;
using TestRouterMvvm.ViewModels;
using TestRouterMvvm.ViewModels.Settings;

namespace TestRouterMvvm.Views.Settings;

public partial class ImportExportSettingsView : ReactiveUserControl<ImportExportSettingsViewModel> {
    public ImportExportSettingsView() { // designer support

        InitializeComponent();
        if (TopLevel.GetTopLevel(this) is TopLevel topLevel) {
            ViewModel = new ImportExportSettingsViewModel(new FileDialogService(topLevel));
            DataContext = ViewModel;
        }

        //ViewModel
    }

}