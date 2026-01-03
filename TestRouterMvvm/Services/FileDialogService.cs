using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRouterMvvm.Services {

    public sealed class FileDialogService(TopLevel topLevel) : IFileDialogService {
        private readonly TopLevel _topLevel = topLevel;

        public Task<IReadOnlyList<IStorageFile>> OpenFilesAsync(FilePickerOpenOptions options)
            => _topLevel.StorageProvider?.OpenFilePickerAsync(options) ?? Task.FromResult<IReadOnlyList<IStorageFile>>(Array.Empty<IStorageFile>());

        public Task<IStorageFile?> SaveFileAsync(FilePickerSaveOptions options)
            => _topLevel.StorageProvider?.SaveFilePickerAsync(options) ?? Task.FromResult<IStorageFile?>(null);

        public Task<IStorageBookmarkFile?> OpenFileBookmarkAsync(string fileBookmark)
            => _topLevel.StorageProvider?.OpenFileBookmarkAsync(fileBookmark) ?? Task.FromResult<IStorageBookmarkFile?>(null);

        public Task<IStorageBookmarkFolder?> OpenFolderBookmarkAsync(string folderBookmark)
            => _topLevel.StorageProvider?.OpenFolderBookmarkAsync(folderBookmark) ?? Task.FromResult<IStorageBookmarkFolder?>(null);

        public async Task ReleaseFileBookmarkAsync(string bookmark) {
            if (await OpenFileBookmarkAsync(bookmark) is IStorageBookmarkItem bi) {
                await bi.ReleaseBookmarkAsync();
                bi.Dispose();
            }
        }
        public async Task ReleaseFolderBookmarkAsync(string bookmark) {
            if (await OpenFolderBookmarkAsync(bookmark) is IStorageBookmarkItem bi) {
                await bi.ReleaseBookmarkAsync();
                bi.Dispose();
            }
        }

        public async Task<IStorageFolder?> PickFolderAsync(FolderPickerOpenOptions options) {
            if (_topLevel.StorageProvider is null)
                return null;
            var folders = await _topLevel.StorageProvider.OpenFolderPickerAsync(options);
            return folders.FirstOrDefault();
        }

        //For completion.  Not really needed
        public Task<string?> SaveBookmarkAsync(IStorageItem item) {
            return item.SaveBookmarkAsync();
        }

    }
}
