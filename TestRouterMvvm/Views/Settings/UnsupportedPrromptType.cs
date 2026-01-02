using System;

namespace TestRouterMvvm.Views.Settings {
    [Serializable]
    internal class UnsupportedPromptType : Exception {
        public UnsupportedPromptType() {
        }

        public UnsupportedPromptType(string? message) : base(message) {
        }

        public UnsupportedPromptType(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}