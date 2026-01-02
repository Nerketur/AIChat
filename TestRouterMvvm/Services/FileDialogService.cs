using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouterMvvm.Services {

    public sealed class FileDialogService : IFileDialogService {
        private readonly TopLevel _topLevel;
        public FileDialogService(TopLevel topLevel) => _topLevel = topLevel;

        public Task<IReadOnlyList<IStorageFile>> OpenFilesAsync(FilePickerOpenOptions options)
            => _topLevel.StorageProvider?.OpenFilePickerAsync(options) ?? Task.FromResult<IReadOnlyList<IStorageFile>>(Array.Empty<IStorageFile>());

        public Task<IStorageFile?> SaveFileAsync(FilePickerSaveOptions options)
            => _topLevel.StorageProvider?.SaveFilePickerAsync(options) ?? Task.FromResult<IStorageFile?>(null);

        public async Task<IStorageFolder?> PickFolderAsync(FolderPickerOpenOptions options) {
            if (_topLevel.StorageProvider is null)
                return null;
            var folders = await _topLevel.StorageProvider.OpenFolderPickerAsync(options);
            return folders.FirstOrDefault();
        }
    }
}
