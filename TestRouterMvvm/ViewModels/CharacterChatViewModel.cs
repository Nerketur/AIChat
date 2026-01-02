using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using TestRouterMvvm.Models;
using TestRouterMvvm.Models.ChatMessages;

namespace TestRouterMvvm.ViewModels {
    public class CharacterChatViewModel(IScreen screen, CharacterViewModel character, List<Scenario> scenarioList, int scenarioIndex) : ViewModelBase, IRoutableViewModel {
        private List<IChatMessage> _chatHistory = [..
            scenarioList[scenarioIndex].Messages
                                       .Prepend(scenarioList[scenarioIndex].FirstMessage)
        ];
        private Scenario _currentScenario = scenarioList[scenarioIndex];
        private List<Scenario> _scenarioList = scenarioList;
        private UserPersona _userChatting = UserPersona.Default;
        private string _nextMessage = string.Empty;

        public List<IChatMessage> ChatHistory {
            get {
                ((AIChatMessage)_chatHistory[0]).Outputs[0].Text = ((AIChatMessage)_chatHistory[0]).Outputs[0].Text.Replace("{user}", _userChatting.Name).Replace("{character}", CharacterChatting.Model.Name);
                return _chatHistory;
            }

            set => this.RaiseAndSetIfChanged(ref _chatHistory, value);
        }
        public string NextMessage { get => _nextMessage; set => this.RaiseAndSetIfChanged(ref _nextMessage, value); }
        public CharacterViewModel CharacterChatting { get; set; } = character;
        public string UserFormattedPersona => UserChatting.FormattedPersona.Replace("{character}", CharacterChatting.Model.Name);
        public string CharacterFormattedPersona => CharacterChatting.Model.FormattedPersona.Replace("{user}", UserChatting.Name);
        public string FormattedNarrative => CurrentScenario.Narrative.Replace("{character}", CharacterChatting.Model.Name).Replace("{user}", UserChatting.Name);

        public UserPersona UserChatting { get => _userChatting; set => this.RaiseAndSetIfChanged(ref _userChatting, value); }
        public Scenario CurrentScenario {
            get => _currentScenario;
            set {
                if (value != null) {
                    //only change if different
                    ChatHistory = [.. value.Messages.Prepend(value.FirstMessage)];
                    this.RaiseAndSetIfChanged(ref _currentScenario, value);
                }
            }
        }
        public List<Scenario> ScenarioList {
            get => _scenarioList;
            set => this.RaiseAndSetIfChanged(ref _scenarioList, value);
        }
        public IObservable<bool> GetCountIsGreaterThan0 {
            get => this.WhenAnyValue(
                    x => x.ScenarioList,
                    (scenarioList) => scenarioList.Count > 0
                ).ObserveOn(RxApp.MainThreadScheduler);
        }
        public AIModel ModelUsed { get; set; } = new AIModel() { Name = "Jeff" };

        public string? UrlPathSegment => "Chat";

        public IScreen HostScreen => screen;

        public CharacterChatViewModel() : this(null!, new(null), [new()], 0) { }

        public ReactiveCommand<Unit, Unit> SendMessageCommand
            => ReactiveCommand.Create(() => {
                if (!string.IsNullOrWhiteSpace(NextMessage)) {
                    ChatHistory = [.. ChatHistory, new ChatMessage() {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Text = NextMessage,
                    }];
                    NextMessage = string.Empty;
                }
            });

        public ReactiveCommand<Scenario, Unit> DeleteScenarioCommand
            => ReactiveCommand.Create<Scenario>(
                (scenario) => {
                    if (ScenarioList.Count > 1 && ScenarioList.Contains(scenario)) {
                        var newList = ScenarioList.Where(s => s != scenario).ToList();
                        ScenarioList = newList;
                        if (CurrentScenario == scenario) {
                            CurrentScenario = ScenarioList.First();
                        }
                    }
                },
                canExecute: this.WhenAnyValue(
                    x => x.ScenarioList,
                    (scenarioList) => scenarioList.Count > 1
                ).ObserveOn(RxApp.MainThreadScheduler)
            );
        public ReactiveCommand<Scenario, Unit> CopyScenarioCommand
            => ReactiveCommand.Create<Scenario>(
                (scenario) => {
                    var newList = ScenarioList.Append(scenario.ShallowCopyNoMessages()).ToList();
                    ScenarioList = newList;
                    CurrentScenario = ScenarioList.Last();
                },
                canExecute: GetCountIsGreaterThan0
            );
    }
}
