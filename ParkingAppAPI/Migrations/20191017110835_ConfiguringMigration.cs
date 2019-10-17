using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingAppAPI.Migrations
{
    public partial class ConfiguringMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("894a69be-592f-42bf-b01f-813fe991a916"), false, 0, 0 },
                    { new Guid("5975e9c8-b086-4277-a5e7-23d9160b5625"), false, 0, 1 },
                    { new Guid("5fc199eb-b015-4203-ae99-022d47ebfa34"), false, 0, 2 },
                    { new Guid("4afb706a-1d15-4d4c-b8e8-0f5a6a255235"), false, 0, 3 },
                    { new Guid("0a1682d7-cab4-4aa9-8281-3adeeccc6e1a"), false, 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("0a1682d7-cab4-4aa9-8281-3adeeccc6e1a"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("4afb706a-1d15-4d4c-b8e8-0f5a6a255235"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("5975e9c8-b086-4277-a5e7-23d9160b5625"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("5fc199eb-b015-4203-ae99-022d47ebfa34"));

            migrationBuilder.DeleteData(
                table: "slots",
                keyColumn: "Id",
                keyValue: new Guid("894a69be-592f-42bf-b01f-813fe991a916"));

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
    }
}
