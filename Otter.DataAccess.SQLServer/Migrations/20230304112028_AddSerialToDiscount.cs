using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddSerialToDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Serial",
                table: "Discounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Discounts");
        }
    }
}
