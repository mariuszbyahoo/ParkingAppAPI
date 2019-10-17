using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingAppAPI.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("c37e227b-7487-427a-8dc5-004d8ac45352"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("cc823fca-9054-4cd2-828a-40348834ec6e"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("f4f2801b-9c02-42ab-9c79-d1e0e6833d3b"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("fde8d12a-1d6e-43eb-8a00-7bdda7c8c84b"));

            migrationBuilder.InsertData(
                table: "slots",
                columns: new[] { "Id", "IsOccupied", "posX", "posY" },
                values: new object[,]
                {
                    { new Guid("871bc1d3-b937-4b5f-9899-fe800eefd741"), false, 0, 0 },
                    { new Guid("e513f252-828e-46d4-9dda-4ffb4172c233"), false, 0, 1 },
                    { new Guid("812f59e0-2578-4ac4-bed2-a6e6b73db7c2"), false, 0, 2 },
                    { new Guid("00f31b3b-0fd9-4ec6-8b89-81a9bcce5713"), false, 0, 3 },
                    { new Guid("64319ac9-8bef-4369-bbfb-5b902da068c1"), false, 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("00f31b3b-0fd9-4ec6-8b89-81a9bcce5713"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("64319ac9-8bef-4369-bbfb-5b902da068c1"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("812f59e0-2578-4ac4-bed2-a6e6b73db7c2"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("871bc1d3-b937-4b5f-9899-fe800eefd741"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("e513f252-828e-46d4-9dda-4ffb4172c233"));

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
    }
}
