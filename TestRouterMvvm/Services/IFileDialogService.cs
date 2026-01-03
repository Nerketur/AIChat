using Avalonia.Platform.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestRouterMvvm.Services {
    public interface IFileDialogService {
        Task<IReadOnlyList<IStorageFile>> OpenFilesAsync(FilePickerOpenOptions options);
        Task<IStorageFile?> SaveFileAsync(FilePickerSaveOptions options);
        Task<IStorageFolder?> PickFolderAsync(FolderPickerOpenOptions options);
        Task<IStorageBookmarkFile?> OpenFileBookmarkAsync(string fileBookmark);
        Task<IStorageBookmarkFolder?> OpenFolderBookmarkAsync(string folderBookmark);
        Task ReleaseFileBookmarkAsync(string bookmark);
        Task ReleaseFolderBookmarkAsync(string bookmark);
        Task<string?> SaveBookmarkAsync(IStorageItem item);
    }
}
