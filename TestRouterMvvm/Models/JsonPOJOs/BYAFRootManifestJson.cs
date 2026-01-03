using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TestRouterMvvm.Models.BYAFRelated;

namespace TestRouterMvvm.Models.JsonPOJOs {
    public class BYAFRootManifestJson {
        [JsonPropertyName("schemaVersion")]
        public int SchemaVersion { get; set; } = 1;
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("author")]
        public BYAIAuthor? Author { get; set; } = null;
        [JsonPropertyName("characters")]
        public List<string> CharactersJSON { get; set; } = [];
        [JsonPropertyName("scenarios")]
        public List<string> ScenariosJSON { get; set; } = [];

    }
}
