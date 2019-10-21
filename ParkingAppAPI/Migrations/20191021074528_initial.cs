using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "slots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    posX = table.Column<int>(nullable: false),
                    posY = table.Column<int>(nullable: false),
                    IsOccupied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slots", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "slots",
                columns: new[] { "Id", "IsOccupied", "posX", "posY" },
                values: new object[,]
                {
                    { new Guid("2a6964b5-12f5-45c4-9b51-c619642815cd"), false, 0, 0 },
                    { new Guid("f31bf444-0966-4580-84cf-36823400e0de"), false, 0, 1 },
                    { new Guid("d84ed0c3-8fe5-4b0a-ad71-f4551830ccbf"), false, 0, 2 },
                    { new Guid("38693933-1c78-4a65-9e46-06cc258a4194"), false, 0, 3 },
                    { new Guid("a89afa90-88c2-440d-a84e-bbce6d8a203a"), false, 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slots");
        }
    }
}
