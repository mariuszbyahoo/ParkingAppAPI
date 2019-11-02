using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.API.Migrations
{
    public partial class deleteCoords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_slots",
                table: "slots");

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("2a6964b5-12f5-45c4-9b51-c619642815cd"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("38693933-1c78-4a65-9e46-06cc258a4194"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("a89afa90-88c2-440d-a84e-bbce6d8a203a"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("d84ed0c3-8fe5-4b0a-ad71-f4551830ccbf"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("f31bf444-0966-4580-84cf-36823400e0de"));

            migrationBuilder.DropColumn(
                name: "posX",
                table: "slots");

            migrationBuilder.DropColumn(
                name: "posY",
                table: "slots");

            migrationBuilder.RenameTable(
                name: "slots",
                newName: "Slots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "slots");

            migrationBuilder.AddColumn<int>(
                name: "posX",
                table: "slots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "posY",
                table: "slots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_slots",
                table: "slots",
                column: "Id");

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
    }
}
