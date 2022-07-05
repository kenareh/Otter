using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddBaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 2L, "IPGTerminalId", "08069161" },
                    { 3L, "IPGAcceptorId", "992180008069161" },
                    { 4L, "IPGPassPhrase", "76FEB0F316883B83" },
                    { 5L, "IPGAccountNumber", "0000113939400" },
                    { 6L, "IPGRsaPublicKey", "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDfA/K5iF5s7GqNpBm+mRdZQvmAmSMpO+65h4jrIEEbS+HoMGWVZsBz+Kmh7PUZX48bqSqIUcIOlF0glxLENGwCaQU2lMrw1CNODqhEKbP4j2VjZisGgUSGv8fmBEpqBjwT1us6r+z0JwlCXeJ46BLAIyzg003PX0iRNjhnzSOx7QIDAQAB" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
