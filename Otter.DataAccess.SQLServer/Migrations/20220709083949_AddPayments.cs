using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PremiumAmount = table.Column<long>(type: "bigint", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PolicyId",
                table: "Payments",
                column: "PolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
