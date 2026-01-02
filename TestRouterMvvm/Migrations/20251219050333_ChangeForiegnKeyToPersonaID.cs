using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForiegnKeyToPersonaID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_UserPersonas_ScenarioId",
                table: "Scenarios");

            migrationBuilder.RenameColumn(
                name: "ScenarioId",
                table: "Scenarios",
                newName: "UserPersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Scenarios_ScenarioId",
                table: "Scenarios",
                newName: "IX_Scenarios_UserPersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_UserPersonas_UserPersonaId",
                table: "Scenarios",
                column: "UserPersonaId",
                principalTable: "UserPersonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_UserPersonas_UserPersonaId",
                table: "Scenarios");

            migrationBuilder.RenameColumn(
                name: "UserPersonaId",
                table: "Scenarios",
                newName: "ScenarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Scenarios_UserPersonaId",
                table: "Scenarios",
                newName: "IX_Scenarios_ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_UserPersonas_ScenarioId",
                table: "Scenarios",
                column: "ScenarioId",
                principalTable: "UserPersonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
