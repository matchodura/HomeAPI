using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SensorType",
                table: "MotionSensors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SensorType",
                table: "LightSensors",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 13, 40, 42, 435, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 13, 40, 42, 438, DateTimeKind.Local).AddTicks(2826));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorType",
                table: "MotionSensors");

            migrationBuilder.DropColumn(
                name: "SensorType",
                table: "LightSensors");

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 13, 39, 13, 491, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 13, 39, 13, 494, DateTimeKind.Local).AddTicks(71));
        }
    }
}
