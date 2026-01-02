namespace TestRouterMvvm.Models.Database {
    internal class DBExampleMessage {
        public int Id { get; set; }
        public int ScenarioId { get; set; }
        public string Messages { get; set; }
        public int? SpeakerId { get; set; } // null for user
        public DBScenario Scenario { get; set; }
        public DBCharacter? Speaker { get; set; } // null for user
    }
}