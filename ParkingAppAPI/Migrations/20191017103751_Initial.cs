using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingAppAPI.Migrations
{
    public partial class Initial : Migration
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
                    { new Guid("f4f2801b-9c02-42ab-9c79-d1e0e6833d3b"), true, 0, 1 },
                    { new Guid("fde8d12a-1d6e-43eb-8a00-7bdda7c8c84b"), false, 0, 2 },
                    { new Guid("cc823fca-9054-4cd2-828a-40348834ec6e"), true, 0, 3 },
                    { new Guid("c37e227b-7487-427a-8dc5-004d8ac45352"), false, 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slots");
        }
    }
}
