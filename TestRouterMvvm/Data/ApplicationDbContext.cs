using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestRouterMvvm.Models.Database;

namespace TestRouterMvvm.Data {

    public class ApplicationDbContext : DbContext {
        internal DbSet<DBUserPersona> UserPersonas { get; set; }
        internal DbSet<DBAIModel> AIModels { get; set; }
        internal DbSet<DBCharacter> Characters { get; set; }
        internal DbSet<DBScenario> Scenarios { get; set; }
        internal DbSet<DBExampleMessage> ExampleMessages { get; set; }
        internal DbSet<EFKeyValuePair<string, string?>> KeyValuePairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=aichat.db")
                          .EnableSensitiveDataLogging()
                          .LogTo(msg => Debug.WriteLine(msg));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //Configure the relations
            modelBuilder.Entity<DBScenario>()
                .HasMany(p => p.DBCharacters)
                .WithMany(c => c.Chats);
            modelBuilder.Entity<DBScenario>()
                .HasOne(p => p.Model)
                .WithMany(c => c.DBScenarios)
                .HasForeignKey(f => f.ModelId);
            modelBuilder.Entity<DBScenario>()
                .HasOne(p => p.DBUserPersona)
                .WithMany(c => c.DBScenarios)
                .HasForeignKey(f => f.UserPersonaId);
            modelBuilder.Entity<DBExampleMessage>()
                .HasOne(p => p.Scenario)
                .WithMany(c => c.ExampleMessages)
                .HasForeignKey(f => f.ScenarioId);
            modelBuilder.Entity<DBExampleMessage>()
                .HasOne(p => p.Speaker)
                .WithMany()
                .HasForeignKey(f => f.SpeakerId)
                .IsRequired(false);

            //Configure additional columns
            //modelBuilder
            //    .Entity<DBScenario>()
            //    .Property(p => p.FirstMessage)
            //    .IsRequired();
        }
    }
}
