using AIChat.ViewModels;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace AIChat.Views {
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {
        public MainWindow() {
            InitializeComponent();
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }

        //private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        //    Debug.WriteLine($"Button clicked! Celsius={Celsius?.Text}");
        //    ConvertCelsiusToFahrenheit();
        //}

        //private void ConvertCelsiusToFahrenheit() {
        //    if (decimal.TryParse(Celsius?.Text ?? "0", out decimal cValue)) {
        //        decimal fValue = (cValue * 9 / 5) + 32;
        //        Fahrenheit.Text = fValue.ToString("F2");
        //    }
        //}

        //private void Celsius_TextChanged(object? sender, TextChangedEventArgs e) {
        //    ConvertCelsiusToFahrenheit();
        //}
    }
}