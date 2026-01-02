using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;

namespace AIChat.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        //public string Greeting { get; } = "Welcome to Avalonia!";

        //private string _description = string.Empty;
        //public string Description
        //{
        //    get => _description;
        //    set => this.RaiseAndSetIfChanged(ref _description, value);
        //}

        //private string _userName = string.Empty;

        //public string UserName {
        //    get { return _userName; }
        //    set { this.RaiseAndSetIfChanged(ref _userName, value); }
        //}

        //public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; } = new();

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;

        public MainWindowViewModel() {
            //IObservable<bool> isInputValid = this.WhenAnyValue(
            //                x => x.UserName,
            //                x => !string.IsNullOrWhiteSpace(x) && x.Length > 7
            //            );
            //SubmitCommand = ReactiveCommand.Create(() => {
            //    Debug.WriteLine("The submit command was run.");
            //}, isInputValid);
            // Manage the routing state. Use the Router.Navigate.Execute
            // command to navigate to different view models. 
            //
            // Note, that the Navigate.Execute method accepts an instance 
            // of a view model, this allows you to pass parameters to 
            // your view models, or to reuse existing view models.
            //
            GoNext = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new FirstViewModel(this))
            );

        }
    }
}
