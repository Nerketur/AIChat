using System;

namespace TestRouterMvvm.Views.Settings {
    [Serializable]
    internal class UnsupportedChatMessageType : Exception {
        public UnsupportedChatMessageType() {
        }

        public UnsupportedChatMessageType(string? message) : base(message) {
        }

        public UnsupportedChatMessageType(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}