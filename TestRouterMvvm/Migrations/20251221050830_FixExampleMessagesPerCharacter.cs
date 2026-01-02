using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class FixExampleMessagesPerCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExampleMessages",
                table: "Scenarios");

            migrationBuilder.CreateTable(
                name: "ExampleMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScenarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeakerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleMessages_Characters_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExampleMessages_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExampleMessages_ScenarioId",
                table: "ExampleMessages",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleMessages_SpeakerId",
                table: "ExampleMessages",
                column: "SpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleMessages");

            migrationBuilder.AddColumn<string>(
                name: "ExampleMessages",
                table: "Scenarios",
                type: "TEXT",
                nullable: true);
        }
    }
}
