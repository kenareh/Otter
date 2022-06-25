using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class PolicyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DarkDotTestState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MicrophoneTestState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SquareTouchTestState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WhiteDotTestState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DarkDotTestState",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "MicrophoneTestState",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "SquareTouchTestState",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "WhiteDotTestState",
                table: "Policies");
        }
    }
}
