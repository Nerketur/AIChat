using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestRouterMvvm.Models.JsonPOJOs;

namespace TestRouterMvvm.Models.BYAFRelated {
    public class BYAFFile {
        public string Version { get; set; } = "0.1.0";
        public string SchemaVersion { get; set; } = "1";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public BYAIAuthor? Author { get; set; } = null;
        public List<BYAFCharacterManifestJson> Characters { get; set; } = [];
        public List<BYAFScenarioManifestJson> Scenarios { get; set; } = [];

        public static BYAFFile LoadFromJSON(string json) {
            return JsonSerializer.Deserialize<BYAFFile>(json) ?? new BYAFFile();
        }
        public static BYAFFile LoadFromBYAFFile(string path) {

            //Open file as ZIP archive
            using ZipArchive archive = ZipFile.OpenRead(path);
            return LoadFromBYAFFile(archive, path);
        }
        public static async Task<BYAFFile> LoadFromBYAFFile(IStorageFile file) {

            //Open file as ZIP archive
            await using var stream = await file.OpenReadAsync();
            return LoadFromBYAFFile(stream, file.TryGetLocalPath());
        }
        public static BYAFFile LoadFromBYAFFile(Stream zipStream, string? path) {

            //Open file as ZIP archive
            using ZipArchive archive = new(zipStream, ZipArchiveMode.Read);
            return LoadFromBYAFFile(archive, path);
        }
        public static BYAFFile LoadFromBYAFFile(ZipArchive arch, string? path) {
            //Open file as ZIP archive
            using ZipArchive archive = arch;
            BYAFFile byafFile = new();

            ZipArchiveEntry? entry = archive.GetEntry("manifest.json") ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file");
            using Stream stream = entry.Open();
            BYAFRootManifestJson rootManifest = JsonSerializer.Deserialize<BYAFRootManifestJson>(stream) ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file");

            //Load characters
            var characterList = rootManifest.CharactersJSON.Select(jsonPath => {
                ZipArchiveEntry? charEntry = archive.GetEntry(jsonPath) ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file");
                using Stream charStream = charEntry.Open();
                var charJson = JsonSerializer.Deserialize<BYAFCharacterManifestJson>(charStream) ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file");
                charJson.Images.ForEach(cji => {
                    string imgPath = Path.Combine(Path.GetDirectoryName(jsonPath) ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file"), cji.Path).Replace('\\', '/');
                    using Stream imgStream = archive.GetEntry(imgPath)?.Open() ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file");

                    using var memory = new MemoryStream();
                    imgStream.CopyTo(memory);
                    memory.Seek(0, SeekOrigin.Begin);

                    cji.Image = new Bitmap(memory);
                });
                return charJson;
            });
            var scenarioList = rootManifest.ScenariosJSON.Select(jsonPath => {
                ZipArchiveEntry? scenEntry = archive.GetEntry(jsonPath) ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file");
                using Stream scenStream = scenEntry.Open();
                return JsonSerializer.Deserialize<BYAFScenarioManifestJson>(scenStream) ?? throw new InvalidBYAFFileException($"Archive at path '${path}' not a valid BYAF file");
            });
            return new() {
                Version = "0.1.0",
                SchemaVersion = rootManifest.SchemaVersion.ToString(),
                Author = rootManifest.Author,
                CreatedAt = rootManifest.CreatedAt,
                Characters = [.. characterList],
                Scenarios = [.. scenarioList],
            };
        }
    }

    public class BYAIAuthor {
        public string Name { get; set; } = "Unknown Author";
        public Uri? Contact { get; set; } = null;
    }
}
