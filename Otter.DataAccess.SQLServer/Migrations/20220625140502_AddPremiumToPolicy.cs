using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddPremiumToPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Cities_CityId",
                table: "Policies");

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "Policies",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "BasePremium",
                table: "Policies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Discount",
                table: "Policies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FinalPremium",
                table: "Policies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "PremiumRate",
                table: "Policies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "RemainingLimitedCount",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Cities_CityId",
                table: "Policies",
                column: "CityId",
                principalSchema: "Base",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Cities_CityId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "BasePremium",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "FinalPremium",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "PremiumRate",
                table: "Policies");

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "Policies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RemainingLimitedCount",
                table: "Discounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Cities_CityId",
                table: "Policies",
                column: "CityId",
                principalSchema: "Base",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
