using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddIndexAndEnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnName",
                schema: "Base",
                table: "Provinces",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                schema: "Base",
                table: "Provinces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EnName",
                schema: "Base",
                table: "Models",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                schema: "Base",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EnName",
                schema: "Base",
                table: "Cities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                schema: "Base",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EnName",
                schema: "Base",
                table: "Brands",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                schema: "Base",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnName",
                schema: "Base",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Index",
                schema: "Base",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "EnName",
                schema: "Base",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Index",
                schema: "Base",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "EnName",
                schema: "Base",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Index",
                schema: "Base",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "EnName",
                schema: "Base",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Index",
                schema: "Base",
                table: "Brands");
        }
    }
}
