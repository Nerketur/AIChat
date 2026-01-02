using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AIModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Persona = table.Column<string>(type: "TEXT", nullable: false),
                    IsMature = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Persona = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EFKeyValuePair<string, string>",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    DBCharacterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFKeyValuePair<string, string>", x => x.Key);
                    table.ForeignKey(
                        name: "FK_EFKeyValuePair<string, string>_Characters_DBCharacterId",
                        column: x => x.DBCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScenarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    FormattingInstructions = table.Column<string>(type: "TEXT", nullable: false),
                    MinP = table.Column<decimal>(type: "TEXT", nullable: false),
                    MinPEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Temperature = table.Column<decimal>(type: "TEXT", nullable: false),
                    RepeatPenalty = table.Column<decimal>(type: "TEXT", nullable: false),
                    RepeatLastN = table.Column<decimal>(type: "TEXT", nullable: false),
                    TopK = table.Column<decimal>(type: "TEXT", nullable: false),
                    TopP = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExampleMessages = table.Column<string>(type: "TEXT", nullable: true),
                    CanDeleteExampleMessages = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstMessage = table.Column<string>(type: "TEXT", nullable: false),
                    Narrative = table.Column<string>(type: "TEXT", nullable: false),
                    PromptTemplate = table.Column<int>(type: "INTEGER", nullable: false),
                    Grammar = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scenarios_AIModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "AIModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scenarios_UserPersonas_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "UserPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBCharacterDBScenario",
                columns: table => new
                {
                    ChatsId = table.Column<int>(type: "INTEGER", nullable: false),
                    DBCharactersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCharacterDBScenario", x => new { x.ChatsId, x.DBCharactersId });
                    table.ForeignKey(
                        name: "FK_DBCharacterDBScenario_Characters_DBCharactersId",
                        column: x => x.DBCharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DBCharacterDBScenario_Scenarios_ChatsId",
                        column: x => x.ChatsId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBCharacterDBScenario_DBCharactersId",
                table: "DBCharacterDBScenario",
                column: "DBCharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_EFKeyValuePair<string, string>_DBCharacterId",
                table: "EFKeyValuePair<string, string>",
                column: "DBCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenarios_ModelId",
                table: "Scenarios",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenarios_ScenarioId",
                table: "Scenarios",
                column: "ScenarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBCharacterDBScenario");

            migrationBuilder.DropTable(
                name: "EFKeyValuePair<string, string>");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "AIModels");

            migrationBuilder.DropTable(
                name: "UserPersonas");
        }
    }
}
