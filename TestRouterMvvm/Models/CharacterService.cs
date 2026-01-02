using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Collections.Generic;
using System.Linq;
using TestRouterMvvm.Data;
using TestRouterMvvm.Models.ChatMessages;
using TestRouterMvvm.Models.Database;
using TestRouterMvvm.ViewModels;

namespace TestRouterMvvm.Models {
    internal static class CharacterService {

        public static List<CharacterViewModel> AllCharacters = [
            new CharacterViewModel(new() {
                DisplayName = "Alice",
                Name = "Alice",
                Author = "Author1",
                Persona = "A curious girl who loves adventures.",
                ImagePath = new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/alice.png"))),
                IsMature = false,
                Lorebook = new Dictionary<string, string?> {
                    { "Background", "Alice is from a small village and dreams of exploring the world." },
                    { "Abilities", "Quick thinker and agile." }
                }
            }),
            new CharacterViewModel(new() {
                DisplayName = "Example Character",
                Name = "ExampleName",
                Author = "AuthorName",
                Persona = "This is an example persona.",
                ImagePath = new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/example.png"))),
                IsMature = false,
                Lorebook = new Dictionary<string, string?> {
                    { "Background", "This is the background lore of the example character." },
                    { "Abilities", "These are the abilities of the example character." }
                }
            }),
            new CharacterViewModel(new() {
                DisplayName = "Bob",
                Name = "Bob",
                Author = "Author2",
                Persona = "A brave warrior with a strong sense of justice.",
                ImagePath = new Bitmap(AssetLoader.Open(new("avares://TestRouterMvvm/Assets/Images/bob.png"))),
                IsMature = true,
                Lorebook = new Dictionary<string, string?> {
                    { "Background", "Bob hails from a lineage of warriors and has fought in many battles." },
                    { "Abilities", "Expert swordsman and tactician." }
                }
            }),
        ];

        public static List<CharacterCardViewModel> AllCharacterCards = [..
            AllCharacters.Select(c => new CharacterCardViewModel() {
                Character = c,
                Scenarios = [new()]
            })
        ];

        public static void AddCharacterCard(CharacterCardViewModel character) {
            AllCharacterCards.Add(character);
        }
        public static void AddCharacterCards(IEnumerable<CharacterCardViewModel> characters) {
            AllCharacterCards.AddRange(characters);
        }
        public static void RemoveCharacterCard(CharacterCardViewModel character) {
            AllCharacterCards.Remove(character);
        }
        public static void AddCharacter(CharacterViewModel character) {
            AllCharacters.Add(character);
        }
        public static void AddCharacters(IEnumerable<CharacterViewModel> characters) {
            AllCharacters.AddRange(characters);
        }
        public static void RemoveCharacter(CharacterViewModel character) {
            AllCharacters.Remove(character);
        }

        //internal static void LoadCharacterCardsFromDatabase() {
        //    using var context = new ApplicationDbContext();
        //    var dbCharacters = context.Characters.ToList();
        //    AllCharacterCards.Clear();
        //    foreach (var dbCharacter in dbCharacters) {
        //        var characterViewModel = new CharacterViewModel(new() {
        //            Name = dbCharacter.Name,
        //            DisplayName = dbCharacter.DisplayName,
        //            Author = dbCharacter.Author,
        //            Persona = dbCharacter.Persona,
        //            IsMature = dbCharacter.IsMature,
        //            ImagePath = dbCharacter.ImagePath
        //        });
        //        var characterCard = new CharacterCardViewModel() {
        //            Character = characterViewModel,
        //            Scenarios = []
        //        };
        //        var dbScenarios = context.Scenarios.Where(s => s.DBCharacters.Any(c => c.Id == dbCharacter.Id)).ToList();
        //        foreach (var dbScenario in dbScenarios) {
        //            var scenarioViewModel = new ScenarioViewModel() {
        //                Title = dbScenario.Title,
        //                Narrative = dbScenario.Narrative,
        //                PromptTemplate = dbScenario.PromptTemplate,
        //                FirstMessage = new AIChatMessage() {
        //                    Role = "ai",
        //                    Outputs = [new AIChatMessageOutput() { Text = dbScenario.FirstMessage }]
        //                },
        //                ExampleMessages = dbScenario.ExampleMessages.Select(msg => {
        //                    if (msg.StartsWith("#ai:")) {
        //                        return new AIChatMessage() {
        //                            Role = "ai",
        //                            Outputs = [new AIChatMessageOutput() { Text = msg.Substring(4) }]
        //                        } as IChatMessage;
        //                    } else if (msg.StartsWith("#human:")) {
        //                        return new ChatMessage() {
        //                            Role = "human",
        //                            Text = msg.Substring(7)
        //                        } as IChatMessage;
        //                    } else {
        //                        return null;
        //                    }
        //                }).Where(m => m != null).ToList()!,
        //                BackgroundImage = dbScenario.BackgroundImage,
        //                CanDeleteExampleMessages = dbScenario.CanDeleteExampleMessages,
        //                FormattingInstructions = dbScenario.FormattingInstructions,
        //                MinP = dbScenario.MinP,
        //                MinPEnabled = dbScenario.MinPEnabled,
        //                Temperature = dbScenario.Temperature,
        //                RepeatPenalty = dbScenario.RepeatPenalty,
        //                RepeatLastN = dbScenario.RepeatLastN,
        //                TopK = dbScenario.TopK,
        //                TopP = dbScenario.TopP,
        //                Grammar = dbScenario.Grammar,
        //                Messages = dbScenario.Messages
        //            };
        //            characterCard

        internal static void AddCharacterCardsToDatabase(List<CharacterCardViewModel> allCharacterCards) {
            using var context = new ApplicationDbContext();
            DBUserPersona userPersona = UserPersona.Default.ToDatabaseModel();
            context.UserPersonas.Add(userPersona);
            context.SaveChanges();
            foreach (var characterCard in allCharacterCards) {
                //var efKeyValues = characterCard.Character.Model.Lorebook.Select(kv => new EFKeyValuePair<string, string?>() { Key = kv.Key, Value = kv.Value });
                //context.SaveChanges();
                var dbCharacter = new DBCharacter {
                    Name = characterCard.Character.Model.Name,
                    DisplayName = characterCard.Character.Model.DisplayName,
                    Author = characterCard.Character.Model.Author,
                    Persona = characterCard.Character.Model.Persona,
                    IsMature = characterCard.Character.Model.IsMature,
                    //Lorebook = [.. efKeyValues],
                    ImagePath = characterCard.Character.Model.ImagePath,

                };
                foreach (var scenario in characterCard.Scenarios) {
                    DBAIModel model = AIModel.GetNamed(scenario.Model).ToDatabaseModel();
                    context.AIModels.Add(model);
                    context.SaveChanges();
                    var dbScenario = new DBScenario {
                        DBCharacters = [dbCharacter],
                        ImageBookmark = scenario.ImageBookmark,
                        CanDeleteExampleMessages = scenario.CanDeleteExampleMessages,
                        FirstMessage = scenario.FirstMessage.Outputs.FirstOrDefault()?.Text ?? string.Empty,
                        Narrative = scenario.Narrative,
                        PromptTemplate = scenario.PromptTemplate,
                        UserPersonaId = userPersona.Id,
                        ModelId = model.Id,
                        FormattingInstructions = scenario.FormattingInstructions,
                        MinP = scenario.MinP,
                        MinPEnabled = scenario.MinPEnabled,
                        Temperature = scenario.Temperature,
                        RepeatPenalty = scenario.RepeatPenalty,
                        RepeatLastN = scenario.RepeatLastN,
                        TopK = scenario.TopK,
                        TopP = scenario.TopP,
                        Grammar = scenario.Grammar,
                        Messages = scenario.Messages,
                        Title = scenario.Title,
                    };
                    dbScenario.ExampleMessages = scenario.ExampleMessages is List<IChatMessage> ems
                                            ? [.. ems.Select(GetDatabaseText).Select(msg => new DBExampleMessage() { Scenario = dbScenario, Messages = msg })]
                                            : [];

                    context.Scenarios.Add(dbScenario);
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }

        private static string ReplaceSpeakers(string msg, string user, string character) {
            return msg; //.Replace("#ai:", $"#{character}:").Replace("#human:", $"#{user}:");
        }

        private static string GetDatabaseText(IChatMessage em) {
            return em switch {
                ChatMessage msg => msg.Text,
                AIChatMessage aiMsg => aiMsg.Outputs.FirstOrDefault()?.Text ?? string.Empty,
                _ => string.Empty,
            };
        }
    }
}