using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAPI.Migrations
{
    public partial class boxupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoxIP",
                table: "Boxes",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 18, 19, 17, 19, 427, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 18, 19, 17, 19, 430, DateTimeKind.Local).AddTicks(5288));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxIP",
                table: "Boxes");

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
    }
}
