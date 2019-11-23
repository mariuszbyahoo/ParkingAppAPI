using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.API.Migrations
{
    public partial class addingDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "Slots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desc",
                table: "Slots");
        }
    }
}
