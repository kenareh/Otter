using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddScreenTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DarkDotTestState",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "SquareTouchTestState",
                table: "Policies");

            migrationBuilder.RenameColumn(
                name: "WhiteDotTestState",
                table: "Policies",
                newName: "ScreenTestState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScreenTestState",
                table: "Policies",
                newName: "WhiteDotTestState");

            migrationBuilder.AddColumn<bool>(
                name: "DarkDotTestState",
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
        }
    }
}
