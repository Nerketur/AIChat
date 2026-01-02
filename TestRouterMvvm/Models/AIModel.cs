using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRouterMvvm.Models.Database;

namespace TestRouterMvvm.Models {
    public enum AIModelSource {
        None,
        Ollama,
    }

    public static class AIModels {
        public const string Llama2_7B = "Llama2-7B";
        public const string Llama2_13B = "Llama2-13B";
        public const string Llama2_70B = "Llama2-70B";
        public const string Vicuna_7B = "Vicuna-7B";
        public const string Vicuna_13B = "Vicuna-13B";
    }

    public class AIModel {
        public static AIModel Default { get; set; } = new AIModel() {
            Name = AIModels.Llama2_7B,
            Source = AIModelSource.Ollama,
        };
        public required string Name { get; set; }
        public AIModelSource Source { get; set; } = AIModelSource.None;

        internal static AIModel GetNamed(string? model) {
            if (model is null) {
                return Default;
            }
            return new AIModel() {
                Name = model,
            };
        }

        internal DBAIModel ToDatabaseModel() {
            return new DBAIModel() {
                Name = this.Name,
                Source = this.Source,
            };
        }
    }
}
