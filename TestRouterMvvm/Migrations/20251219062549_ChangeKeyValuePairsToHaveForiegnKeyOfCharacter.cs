using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeyValuePairsToHaveForiegnKeyOfCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyValuePairs_Characters_DBCharacterId",
                table: "KeyValuePairs");

            migrationBuilder.DropIndex(
                name: "IX_KeyValuePairs_DBCharacterId",
                table: "KeyValuePairs");

            migrationBuilder.DropColumn(
                name: "DBCharacterId",
                table: "KeyValuePairs");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "KeyValuePairs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KeyValuePairs_CharacterId",
                table: "KeyValuePairs",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyValuePairs_Characters_CharacterId",
                table: "KeyValuePairs",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyValuePairs_Characters_CharacterId",
                table: "KeyValuePairs");

            migrationBuilder.DropIndex(
                name: "IX_KeyValuePairs_CharacterId",
                table: "KeyValuePairs");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "KeyValuePairs");

            migrationBuilder.AddColumn<int>(
                name: "DBCharacterId",
                table: "KeyValuePairs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeyValuePairs_DBCharacterId",
                table: "KeyValuePairs",
                column: "DBCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyValuePairs_Characters_DBCharacterId",
                table: "KeyValuePairs",
                column: "DBCharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
