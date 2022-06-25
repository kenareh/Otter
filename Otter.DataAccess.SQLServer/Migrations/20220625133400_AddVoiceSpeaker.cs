using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddVoiceSpeaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.AddColumn<bool>(
                name: "IsMobileConfirmed",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerTestAttempt",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SpeakerTestNumberId",
                table: "Policies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "SpeakerTestState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Currencies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "PolicyFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyFileType = table.Column<int>(type: "int", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyFiles_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerTestNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerTestNumbers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1L, "PremiumRate", "0.3" });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_SpeakerTestNumberId",
                table: "Policies",
                column: "SpeakerTestNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyFiles_PolicyId",
                table: "PolicyFiles",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_SpeakerTestNumbers_SpeakerTestNumberId",
                table: "Policies",
                column: "SpeakerTestNumberId",
                principalTable: "SpeakerTestNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_SpeakerTestNumbers_SpeakerTestNumberId",
                table: "Policies");

            migrationBuilder.DropTable(
                name: "PolicyFiles");

            migrationBuilder.DropTable(
                name: "SpeakerTestNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Policies_SpeakerTestNumberId",
                table: "Policies");

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "IsMobileConfirmed",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "SpeakerTestAttempt",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "SpeakerTestNumberId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "SpeakerTestState",
                table: "Policies");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Currencies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "LatinName", "Title" },
                values: new object[,]
                {
                    { 1L, "Rial", "ریال" },
                    { 2L, "Dollar", "دلار" },
                    { 3L, "Euro", "یورو" },
                    { 4L, "Dirham", "درهم" }
                });
        }
    }
}
