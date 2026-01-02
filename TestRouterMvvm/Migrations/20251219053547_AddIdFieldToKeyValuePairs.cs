using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class AddIdFieldToKeyValuePairs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyValuePairs",
                table: "KeyValuePairs");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "KeyValuePairs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "KeyValuePairs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyValuePairs",
                table: "KeyValuePairs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyValuePairs",
                table: "KeyValuePairs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "KeyValuePairs");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "KeyValuePairs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyValuePairs",
                table: "KeyValuePairs",
                column: "Key");
        }
    }
}
