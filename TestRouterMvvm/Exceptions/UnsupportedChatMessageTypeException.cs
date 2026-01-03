using System;

namespace TestRouterMvvm.Exceptions {
    [Serializable]
    internal class UnsupportedChatMessageTypeException : Exception {
        public UnsupportedChatMessageTypeException() { }

        public UnsupportedChatMessageTypeException(string? message) : base(message) { }

        public UnsupportedChatMessageTypeException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}