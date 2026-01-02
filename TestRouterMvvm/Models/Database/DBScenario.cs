using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Models.BYAFRelated;
using TestRouterMvvm.Models.ChatMessages;

namespace TestRouterMvvm.Models.Database {
    internal class DBScenario {
        private IImage? _backgroundImage;

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = "Untitled Scenario";
        public int ModelId { get; set; }
        public int UserPersonaId { get; set; }
        public string FormattingInstructions { get; set; } = "No special formatting instructions.";
        public decimal MinP { get; set; }
        public bool MinPEnabled { get; set; }
        public decimal Temperature { get; set; }
        public decimal RepeatPenalty { get; set; }
        public decimal RepeatLastN { get; set; }
        public decimal TopK { get; set; }
        public decimal TopP { get; set; }
        public string? ImageBookmark { get; set; }
        public List<DBExampleMessage>? ExampleMessages { get; set; }
        public bool CanDeleteExampleMessages { get; set; } = true;
        public string FirstMessage { get; set; } = "You, ({character}), are a helpful assistant to {user}.";
        //public AIChatMessage FirstMessage { get; set; } = new AIChatMessage {
        //    Role = "system",
        //    Outputs = [
        //        new() {
        //            Text = "You, ({character}), are a helpful assistant to {user}."
        //        }
        //    ],
        //};
        public string Narrative { get; set; } = "You, ({character}), are a helpful assistant to {user}.";
        public BYAIPromptTemplate PromptTemplate { get; set; } = BYAIPromptTemplate.General;
        public string? Grammar { get; set; }
        [NotMapped]
        public List<IChatMessage> Messages { get; set; } = [
                new ChatMessage() {
                    Role="human",
                    Text="Human First Message"
                },
                new AIChatMessage() {
                    Role="ai",
                    Outputs = [
                        new() {
                            Text = "AI First reply"
                        }
                    ]
                },
                new ChatMessage() {
                    Role="human",
                    Text="Human Second Message"
                },
                new AIChatMessage() {
                    Role="ai",
                    Outputs = [
                        new() {
                            Text = "AI second reply"
                        }
                    ]
                }
            ];

        //Navigation properties

        public List<DBCharacter> DBCharacters { get; set; } = [];
        public DBAIModel Model { get; set; }
        public DBUserPersona DBUserPersona { get; set; }
    }
}
