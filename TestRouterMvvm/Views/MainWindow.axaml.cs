using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Views {
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {

        public MainWindow() {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposables =>
            {
                //this.OneWayBind(ViewModel, vm => vm.Greeting, v => v.GreetingTextBlock.Text)
                //    .DisposeWith(disposables);
            });
            AvaloniaXamlLoader.Load(this);

        }

        private void TabStrip_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
        }
    }
}