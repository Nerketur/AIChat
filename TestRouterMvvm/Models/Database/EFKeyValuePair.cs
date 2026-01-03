namespace TestRouterMvvm.Models.Database {
    internal class EFKeyValuePair<TKey, TValue> {
        public int Id { get; set; }
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public DBCharacter Character { get; set; }
    }
}
