using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestRouterMvvm.Models.JsonPOJOs {
    public class BYAFCharacterManifestJson {
        [JsonIgnore] public string CharacterID { get; set; } = string.Empty;
        [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; set; } = 1;
        [JsonPropertyName("id")] public string Id { get; set; } = Guid.NewGuid().ToString();
        [JsonPropertyName("name")] public string Name { get; set; } = "";
        [JsonPropertyName("displayName")] public string DisplayName { get; set; } = "";
        [JsonPropertyName("isNSFW")] public bool IsNSFW { get; set; }
        [JsonPropertyName("persona")] public string Persona { get; set; } = "";
        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")] public DateTime UpdatedAt { get; set; }
        [JsonPropertyName("loreItems")] public List<BYAFKeyValue> LoreItems { get; set; } = [];
        [JsonPropertyName("images")] public List<BYAFManifestImageProps> Images { get; set; } = [];
    }

    public class BYAFManifestImageProps {
        [JsonPropertyName("path")] public string Path { get; set; } = "";
        [JsonPropertyName("label")] public string Label { get; set; } = "";
        [JsonIgnore] public IImage? Image { get; set; }
    }
    public class BYAFKeyValue {
        [JsonPropertyName("key")]
        public string Key { get; set; } = "";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
