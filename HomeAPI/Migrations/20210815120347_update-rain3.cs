using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAPI.Migrations
{
    public partial class updaterain3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RainStatus",
                table: "RainSensors",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 14, 3, 47, 212, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 14, 3, 47, 215, DateTimeKind.Local).AddTicks(2450));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RainStatus",
                table: "RainSensors");

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 14, 0, 47, 500, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 14, 0, 47, 502, DateTimeKind.Local).AddTicks(8735));
        }
    }
}
