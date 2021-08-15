using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace HomeAPI.Migrations
{
    public partial class updaterain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RainSensors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxID = table.Column<int>(type: "int", nullable: true),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    SensorType = table.Column<string>(type: "text", nullable: true),
                    Rain = table.Column<float>(type: "float", nullable: false),
                    CalledBy = table.Column<string>(type: "text", nullable: true),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RainSensors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RainSensors_Boxes_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Boxes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 13, 58, 51, 416, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "Boxes",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 15, 13, 58, 51, 418, DateTimeKind.Local).AddTicks(6126));

            migrationBuilder.CreateIndex(
                name: "IX_RainSensors_BoxID",
                table: "RainSensors",
                column: "BoxID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RainSensors");

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
    }
}
