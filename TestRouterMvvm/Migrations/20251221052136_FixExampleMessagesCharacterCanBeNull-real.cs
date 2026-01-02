using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRouterMvvm.Migrations
{
    /// <inheritdoc />
    public partial class FixExampleMessagesCharacterCanBeNullreal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpeakerId",
                table: "ExampleMessages",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpeakerId",
                table: "ExampleMessages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
