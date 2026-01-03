using System;

namespace TestRouterMvvm.Exceptions {
    [Serializable]
    internal class InvalidBYAFFileException : Exception {
        public InvalidBYAFFileException() { }

        public InvalidBYAFFileException(string? message) : base(message) { }

        public InvalidBYAFFileException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}