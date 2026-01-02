using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class FixExampleMessagesCharacterCanBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExampleMessages_Characters_SpeakerId",
                table: "ExampleMessages");

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleMessages_Characters_SpeakerId",
                table: "ExampleMessages",
                column: "SpeakerId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExampleMessages_Characters_SpeakerId",
                table: "ExampleMessages");

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleMessages_Characters_SpeakerId",
                table: "ExampleMessages",
                column: "SpeakerId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
