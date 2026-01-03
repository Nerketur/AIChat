using System;

namespace TestRouterMvvm.Exceptions {
    [Serializable]
    internal class UnsupportedPromptTypeException : Exception {
        public UnsupportedPromptTypeException() { }

        public UnsupportedPromptTypeException(string? message) : base(message) { }

        public UnsupportedPromptTypeException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}