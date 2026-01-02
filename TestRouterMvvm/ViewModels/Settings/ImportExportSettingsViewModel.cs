using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Models;
using TestRouterMvvm.Models.BYAFRelated;
using TestRouterMvvm.Models.ChatMessages;
using TestRouterMvvm.Models.JsonPOJOs;
using TestRouterMvvm.Services;
using TestRouterMvvm.Views;
using TestRouterMvvm.Views.Settings;

namespace TestRouterMvvm.ViewModels.Settings {
    public class ImportExportSettingsViewModel : ViewModelBase {
        public ImportExportSettingsViewModel(IFileDialogService fileDialogService) {
            FileDialogService = fileDialogService;
            //DoExport = ReactiveCommand.Create(ExportButton_Click, Observable.Start(() => true));
        }

        public ImportExportSettingsViewModel() : this(null!) { }

        public static string DisplayName { get; } = "Import/Export";

        public IFileDialogService FileDialogService { get; set; }

        public ReactiveCommand<Unit, Unit> DoImport => ReactiveCommand.CreateFromTask(ImportButton_Click, outputScheduler: RxSchedulers.MainThreadScheduler);
        public ReactiveCommand<Unit, Unit> DoExport { get; set; } = ReactiveCommand.Create(() => { });

        //public ReactiveCommand<Unit, Unit> Command { get; } = new ReactiveCommand(() => { });
        private async Task ImportButton_Click() {
            ;
            IReadOnlyList<IStorageFile> files = [];
            if (FileDialogService != null) {
                files = await FileDialogService.OpenFilesAsync(new() {
                    AllowMultiple = true,
                    Title = "Choose a BYAF file",
                    FileTypeFilter = [new("BYAF Files") {
                    Patterns = ["*.byaf"],
                }]
                });
            }
            foreach (var zipFile in files) {
                BYAFFile file = await BYAFFile.LoadFromBYAFFile(zipFile);
                Dictionary<string, string?> lorebook = [];
                file.Characters[0].LoreItems.ForEach(item => {
                    lorebook[item.Key] = item.Value;
                });
                List<Scenario> scenarios = [.. file.Scenarios.Select(sc => new Scenario() {
                CanDeleteExampleMessages = sc.CanDeleteExampleMessages,
                ExampleMessages = sc.ExampleMessages is List<Models.JsonPOJOs.ExampleMessage> msgs
                                    ? [..
                                        msgs.Select<Models.JsonPOJOs.ExampleMessage, IChatMessage>(em => {
                                            if (em.CharacterID == file.Characters[0].CharacterID) {
                                                return new AIChatMessage() {
                                                    Role = "ai",
                                                    Outputs = [new() { Text = em.Text }]
                                                };
                                            } else {
                                                return new ChatMessage() {
                                                    Role = "human",
                                                    Text = em.Text
                                                };
                                            }
                                        })
                                    ]
                                    : [],
                FirstMessage = new AIChatMessage() {
                    Role = "ai",
                    Outputs = [new() { Text = sc.FirstMessages.First().Text }]
                },
                FormattingInstructions = sc.FormattingInstructions,
                Grammar = sc.Grammar,
                MinP = sc.MinP,
                MinPEnabled = sc.MinPEnabled,
                Model = sc.Model,
                Narrative = sc.Narrative,
                RepeatLastN = sc.RepeatLastN,
                RepeatPenalty = sc.RepeatPenalty,
                Temperature = sc.Temperature,
                TopK = sc.TopK,
                TopP = sc.TopP,
                Title = sc.Title,
                PromptTemplate = sc.PromptTemplate switch {
                    "general" => BYAIPromptTemplate.General,
                    "ChatML" => BYAIPromptTemplate.ChatML,
                    "Llama3" => BYAIPromptTemplate.Llama3,
                    "Gemma2" => BYAIPromptTemplate.Gemma2,
                    "CommandR" => BYAIPromptTemplate.CommandR,
                    "MistralInstruct" => BYAIPromptTemplate.MistralInstruct,
                    null => BYAIPromptTemplate.None,
                    _ => throw new UnsupportedPromptType($"Prompt type of {sc.PromptTemplate} is unsupported!")
                },
                Messages = [.. sc.Messages.Select<BYAFChatMessage, IChatMessage>(msg => msg switch {
                    BYAFAIChatMessage aimsg => new AIChatMessage() {
                        Role = "ai",
                        Outputs = [.. aimsg.Outputs.Select(o => new AIChatMessageOutput() {
                            ActiveTimestamp = o.ActiveTimestamp,
                            CreatedAt = o.CreatedAt,
                            Text = o.Text,
                            UpdatedAt = o.UpdatedAt
                        })]
                    },
                    BYAFUserChatMessage umsg => new ChatMessage() {
                        Role = "human",
                        CreatedAt = umsg.CreatedAt,
                        Text = umsg.Text,
                        UpdatedAt = umsg.UpdatedAt
                    },
                    _ => throw new UnsupportedChatMessageType($"Chat message type {msg.GetType()} not supported")
                })],
                BackgroundImage = null
            })];
                CharacterService.AddCharacterCard(new CharacterCardViewModel() {
                    Character = new CharacterViewModel(new() {
                        DisplayName = file.Characters[0].DisplayName + "(Imported Character)",
                        Name = file.Characters[0].Name,
                        Author = file.Author?.Name ?? "Unknown",
                        Persona = file.Characters[0].Persona,
                        Lorebook = lorebook,
                        IsMature = file.Characters[0].IsNSFW,
                        ImagePath = file.Characters[0].Images.FirstOrDefault()?.Image ?? new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/36e6f1f77a7a15b3d1b1fef2cf1b6ff7.jpg"))),
                        Chats = scenarios
                    }),
                    Scenarios = scenarios
                });
            }
            CharacterService.AddCharacterCardsToDatabase(CharacterService.AllCharacterCards);
            Debug.WriteLine("Import complete!");
            Debug.WriteLine(string.Join("\r\n", CharacterService.AllCharacterCards.SelectMany(cc => cc.Scenarios).SelectMany(s => s.ExampleMessages?.Select(em => {
                return $"{em.Role}: => " + em switch {
                    AIChatMessage ai => ai.Outputs.FirstOrDefault()?.Text ?? "",
                    ChatMessage cm => cm.Text,
                    _ => ""
                };
            }) ?? [])));
        }

        private void ExportButton_Click() {
            //if (this.IncludeChats.IsChecked ?? false) {

            //}
            //if (ExcludeChats.IsChecked ?? false) {

            //}

        }


    }
}
