using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSHCTwebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamLeaderFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamLeader",
                table: "Commands",
                newName: "TeamLeaderLastName");

            migrationBuilder.AddColumn<string>(
                name: "TeamLeaderEmail",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeamLeaderFirstName",
                table: "Commands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamLeaderEmail",
                table: "Commands");

            migrationBuilder.DropColumn(
                name: "TeamLeaderFirstName",
                table: "Commands");

            migrationBuilder.RenameColumn(
                name: "TeamLeaderLastName",
                table: "Commands",
                newName: "TeamLeader");
        }
    }
}
