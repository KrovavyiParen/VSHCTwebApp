using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSHCTwebApp.Migrations.VSHCTwebApp
{
    /// <inheritdoc />
    public partial class vbrosproj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableUntil",
                table: "Project",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsManuallyMadeAvailable",
                table: "Project",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableUntil",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsManuallyMadeAvailable",
                table: "Project");
        }
    }
}
