using ReactiveUI;

namespace TestRouterMvvm.ViewModels {
    public class CreateCharacterViewModel(IScreen screen) : ViewModelBase, IRoutableViewModel {
        public static string DisplayName { get; } = "Create Character";
        public string? UrlPathSegment { get; } = DisplayName;

        public IScreen HostScreen => screen;

    }
}
