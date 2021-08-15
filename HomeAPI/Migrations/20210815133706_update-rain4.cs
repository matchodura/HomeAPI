using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAPI.Migrations
{
    public partial class updaterain4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rain",
                table: "Rooms",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 15, 37, 6, 184, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 15, 37, 6, 187, DateTimeKind.Local).AddTicks(2232));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rain",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 14, 5, 34, 88, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 14, 5, 34, 90, DateTimeKind.Local).AddTicks(9941));
        }
    }
}
