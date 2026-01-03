using ReactiveUI;

namespace TestRouterMvvm.ViewModels {
    public class ManageModelsViewModel(IScreen screen) : ViewModelBase, IRoutableViewModel {
        public static string DisplayName { get; } = "Manage Models";
        public string? UrlPathSegment { get; } = DisplayName;

        public IScreen HostScreen => screen;

    }
}
