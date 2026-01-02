using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRouterMvvm.Models.ChatMessages {
    public interface IChatMessageInternal {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Text { get; set; }
    }
}
