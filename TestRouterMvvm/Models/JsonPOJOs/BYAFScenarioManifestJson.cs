using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestRouterMvvm.Models.ChatMessages;

namespace TestRouterMvvm.Models.JsonPOJOs {
    public class BYAFScenarioManifestJson {

        [JsonPropertyName("schemaVersion")]
        public int SchemaVersion { get; set; } = 1;
        
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; } = "gpt-3.5-turbo";

        [JsonPropertyName("formattingInstructions")]
        public string FormattingInstructions { get; set; } = "No special formatting instructions.";

        [JsonPropertyName("minP")]
        public decimal MinP { get; set; }

        [JsonPropertyName("minPEnabled")]
        public bool MinPEnabled { get; set; }

        [JsonPropertyName("temperature")]
        public decimal Temperature { get; set; }

        [JsonPropertyName("repeatPenalty")]
        public decimal RepeatPenalty { get; set; }

        [JsonPropertyName("repeatLastN")]
        public decimal RepeatLastN { get; set; }

        [JsonPropertyName("topK")]
        public decimal TopK { get; set; }

        [JsonPropertyName("topP")]
        public decimal TopP { get; set; }

        [JsonPropertyName("backgroundImagePath")]
        public string BackgroundImagePath { get; set; } = "";

        [JsonPropertyName("exampleMessages")]
        public List<ExampleMessage>? ExampleMessages { get; set; }

        [JsonPropertyName("canDeleteExampleMessages")]
        public bool CanDeleteExampleMessages { get; set; } = true;

        [JsonPropertyName("firstMessages")]
        public List<ExampleMessage> FirstMessages { get; set; } = [];

        [JsonPropertyName("narrative")]
        public string Narrative { get; set; } = "You are a helpful assistant.";

        [JsonPropertyName("promptTemplate")]
        public string? PromptTemplate { get; set; } = "general";

        [JsonPropertyName("grammar")]
        public string? Grammar { get; set; }

        [JsonPropertyName("messages")]
        public List<BYAFChatMessage> Messages { get; set; } = [];
    }

    public class ExampleMessage {

        [JsonPropertyName("characterID")]
        public string CharacterID { get; set; } = "";

        [JsonPropertyName("text")]
        public string Text { get; set; } = "";
    }

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(BYAFAIChatMessage), "ai")]
    [JsonDerivedType(typeof(BYAFUserChatMessage), "human")]
    public abstract class BYAFChatMessage { }
    public class BYAFAIChatMessage : BYAFChatMessage {
        [JsonPropertyName("outputs")]
        public List<BYAFAIOutput> Outputs { get; set; } = [];
    }
    public class BYAFAIOutput : IChatMessageInternal {
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("text")]
        public string Text { get; set; } = "";

        [JsonPropertyName("activeTimestamp")]
        public DateTime ActiveTimestamp { get; set; } = DateTime.UtcNow;
    }
    public class BYAFUserChatMessage : BYAFChatMessage, IChatMessageInternal {
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("text")]
        public string Text { get; set; } = "";
    }

}
