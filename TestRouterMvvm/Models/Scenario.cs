using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using TestRouterMvvm.Models.BYAFRelated;
using TestRouterMvvm.Models.ChatMessages;

namespace TestRouterMvvm.Models {

    public class ScenarioButton : Scenario {
        public ReactiveCommand<Unit, Unit> DoOnClick { get; set; }
        public ScenarioButton() {
            Title = "Button";
            DoOnClick = ReactiveCommand.CreateFromTask(() => System.Threading.Tasks.Task.CompletedTask);
        }
    }

    public class Scenario {
        private string? _title = null;

        public string Title {
            get => string.IsNullOrEmpty(_title) ? "Untitled Scenario" : _title;
            set => _title = value;
        }
        public string? Model { get; set; } = "gpt-3.5-turbo";
        public string FormattingInstructions { get; set; } = "No special formatting instructions.";
        public decimal MinP { get; set; }
        public bool MinPEnabled { get; set; }
        public decimal Temperature { get; set; }
        public decimal RepeatPenalty { get; set; }
        public decimal RepeatLastN { get; set; }
        public decimal TopK { get; set; }
        public decimal TopP { get; set; }
        public string? ImageBookmark { get; set; }
        public IImage? BackgroundImage { get; set; }
        public List<IChatMessage>? ExampleMessages { get; set; }
        public bool CanDeleteExampleMessages { get; set; } = true;
        public AIChatMessage FirstMessage { get; set; } = new AIChatMessage {
            Role = "system",
            Outputs = [
                new() {
                    Text = "You, ({character}), are a helpful assistant to {user}."
                }
            ],
        };
        public string Narrative { get; set; } = "You, ({character}), are a helpful assistant to {user}.";
        public BYAIPromptTemplate PromptTemplate { get; set; } = BYAIPromptTemplate.General;
        public string? Grammar { get; set; }
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
        public string GetTimeAgoFromLastMessage {
            get {
                if (Messages == null || Messages.Count == 0) {
                    return "No messages";
                }
                var lastMessage = Messages[^1];
                var timeSpan = System.DateTime.UtcNow - GetCreateDateTime(lastMessage);
                if (timeSpan.TotalSeconds < 60) {
                    return $"{(int)timeSpan.TotalSeconds} seconds ago";
                } else if (timeSpan.TotalMinutes < 60) {
                    return $"{(int)timeSpan.TotalMinutes} minutes ago";
                } else if (timeSpan.TotalHours < 24) {
                    return $"{(int)timeSpan.TotalHours} hours ago";
                } else {
                    return (int)timeSpan.TotalDays switch {
                        < 30 => $"{(int)timeSpan.TotalDays} days ago",
                        < 365 => $"{(int)(timeSpan.TotalDays / 30)} months ago",
                        _ => $"{(int)(timeSpan.TotalDays / 365)} years ago"
                    };
                }
            }
        }
        private System.DateTime GetCreateDateTime(IChatMessage message) {
            return message switch {
                ChatMessage chatMessage => chatMessage.CreatedAt,
                AIChatMessage aiChatMessage => aiChatMessage.Outputs.Max(m => m.UpdatedAt),
                _ => System.DateTime.UtcNow
            };
        }
        private async Task LoadImageFromBookmarkAsync(Control controlInView) {
            if (!string.IsNullOrEmpty(ImageBookmark)) {
                if (TopLevel.GetTopLevel(controlInView) is TopLevel topLevel) {
                    if (await topLevel.StorageProvider.OpenFileBookmarkAsync(ImageBookmark) is IStorageBookmarkFile isbf)
                        // Successfully opened the bookmarked file.
                        BackgroundImage = (IImage?)isbf;
                }
            }
        }
        //private async Task<IImage?> SaveImageToBookmarkAsync(Control controlInView) {
        //    if (!string.IsNullOrEmpty(ImageBookmark)) {
        //        if (TopLevel.GetTopLevel(controlInView) is TopLevel topLevel) {
        //            if (await topLevel.StorageProvider.OpenFileBookmarkAsync(ImageBookmark) is Avalonia.Platform.Storage.IStorageBookmarkFile isbf)
        //                // Successfully opened the bookmarked file.
        //                return (IImage?)isbf;
        //        }
        //    }
        //    return null;
        //}
        // Example usage
        private async Task<string?> SaveBookmarksAsync(IStorageBookmarkItem item) {
            // A folder must be selected first
            if (item == null) return null;

            return await item.SaveBookmarkAsync();
        }
        public Scenario() { }

        public Scenario ShallowCopy() {
            return (Scenario)this.MemberwiseClone();
        }
        public Scenario ShallowCopyNoMessages() {
            Scenario s = (Scenario)this.MemberwiseClone();
            s.Messages = [];
            return s;
        }
    }
}