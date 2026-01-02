using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyValuePairs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EFKeyValuePair<string, string>_Characters_DBCharacterId",
                table: "EFKeyValuePair<string, string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EFKeyValuePair<string, string>",
                table: "EFKeyValuePair<string, string>");

            migrationBuilder.RenameTable(
                name: "EFKeyValuePair<string, string>",
                newName: "KeyValuePairs");

            migrationBuilder.RenameIndex(
                name: "IX_EFKeyValuePair<string, string>_DBCharacterId",
                table: "KeyValuePairs",
                newName: "IX_KeyValuePairs_DBCharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyValuePairs",
                table: "KeyValuePairs",
                column: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyValuePairs_Characters_DBCharacterId",
                table: "KeyValuePairs",
                column: "DBCharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyValuePairs_Characters_DBCharacterId",
                table: "KeyValuePairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyValuePairs",
                table: "KeyValuePairs");

            migrationBuilder.RenameTable(
                name: "KeyValuePairs",
                newName: "EFKeyValuePair<string, string>");

            migrationBuilder.RenameIndex(
                name: "IX_KeyValuePairs_DBCharacterId",
                table: "EFKeyValuePair<string, string>",
                newName: "IX_EFKeyValuePair<string, string>_DBCharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EFKeyValuePair<string, string>",
                table: "EFKeyValuePair<string, string>",
                column: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_EFKeyValuePair<string, string>_Characters_DBCharacterId",
                table: "EFKeyValuePair<string, string>",
                column: "DBCharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
