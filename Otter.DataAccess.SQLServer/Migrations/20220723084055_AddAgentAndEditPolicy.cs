using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddAgentAndEditPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AgentId",
                table: "Policies",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CameraFileState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ImeiFileState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneFileBoxState",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_AgentId",
                table: "Policies",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Agents_AgentId",
                table: "Policies",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Agents_AgentId",
                table: "Policies");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Policies_AgentId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "CameraFileState",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "ImeiFileState",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "PhoneFileBoxState",
                table: "Policies");
        }
    }
}
