using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSHCTwebApp.Migrations
{
    /// <inheritdoc />
    public partial class langteam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgrammingLanguages",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "TechStack",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgrammingLanguages",
                table: "Commands");

            migrationBuilder.DropColumn(
                name: "TechStack",
                table: "Commands");
        }
    }
}
