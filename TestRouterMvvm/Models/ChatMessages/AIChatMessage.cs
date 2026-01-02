using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouterMvvm.Models.ChatMessages {
    public class AIChatMessage : IChatMessage {
        public string Role { get; set; } = "assistant"; // Possible values: "system", "user", "assistant"
        public List<AIChatMessageOutput> Outputs { get; set; } = [];
    }
    public class AIChatMessageOutput : IChatMessageInternal {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string Text { get; set; } = "";
        public DateTime ActiveTimestamp { get; set; } = DateTime.UtcNow;
    }
}
