using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSHCTwebApp.Migrations
{
    /// <inheritdoc />
    public partial class TakeProj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TakenByTeamId",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TakenByTeamName",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TakenByTeamId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TakenByTeamName",
                table: "Project");
        }
    }
}
