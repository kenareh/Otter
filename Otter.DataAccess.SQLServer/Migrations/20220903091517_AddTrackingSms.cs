using Microsoft.EntityFrameworkCore.Migrations;

namespace Otter.DataAccess.SQLServer.Migrations
{
    public partial class AddTrackingSms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSendTrackingSms",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSendTrackingSms",
                table: "Policies");
        }
    }
}
