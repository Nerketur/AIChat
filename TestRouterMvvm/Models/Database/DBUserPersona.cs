using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestRouterMvvm.Models.Database {
    internal class DBUserPersona {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Persona { get; set; }
        public string? ImageBookmark { get; set; } // optional image bookmark for the persona

        //Navigation properties
        public List<DBScenario> DBScenarios { get; set; }

    }
}
