using System;

namespace TestRouterMvvm.Models.ChatMessages {
    public class ChatMessage : IChatMessage, IChatMessageInternal {
        public string Role { get; set; } = "user"; // Possible values: "system", "user", "assistant"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string Text { get; set; } = "";

    }
}
