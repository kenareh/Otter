using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class ChangeDiscountProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MultipleCount",
                table: "Discounts",
                newName: "RemainingLimitedCount");

            migrationBuilder.AddColumn<int>(
                name: "LimitedCount",
                table: "Discounts",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitedCount",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "RemainingLimitedCount",
                table: "Discounts",
                newName: "MultipleCount");
        }
    }
}
