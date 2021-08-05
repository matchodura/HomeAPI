using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace HomeAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxName = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DHTId = table.Column<int>(type: "int", nullable: false),
                    MotionSensorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bulbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LampId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    CommandCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BulbsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LampId = table.Column<int>(type: "int", nullable: true),
                    MethodName = table.Column<string>(type: "text", nullable: true),
                    MethodValue = table.Column<string>(type: "text", nullable: true),
                    DateSent = table.Column<DateTime>(type: "datetime", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulbsHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DHTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxId = table.Column<int>(type: "int", nullable: true),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    Device = table.Column<string>(type: "text", nullable: true),
                    Temperature = table.Column<float>(type: "float", nullable: false),
                    Humidity = table.Column<float>(type: "float", nullable: false),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CalledBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DHTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DHTs_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LightSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxId = table.Column<int>(type: "int", nullable: true),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    Device = table.Column<string>(type: "text", nullable: true),
                    Luxes = table.Column<float>(type: "float", nullable: false),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CalledBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LightSensors_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotionSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxId = table.Column<int>(type: "int", nullable: true),
                    Device = table.Column<string>(type: "text", nullable: true),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotionSensors_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BoxId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "datetime", nullable: false),
                    CalledBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Temperature = table.Column<string>(type: "text", nullable: true),
                    Humidity = table.Column<string>(type: "text", nullable: true),
                    Luxes = table.Column<float>(type: "float", nullable: false),
                    AlarmMessage = table.Column<string>(type: "text", nullable: true),
                    HomeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Home_HomeID",
                        column: x => x.HomeID,
                        principalTable: "Home",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DHTs_BoxId",
                table: "DHTs",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_LightSensors_BoxId",
                table: "LightSensors",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensors_BoxId",
                table: "MotionSensors",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HomeID",
                table: "Rooms",
                column: "HomeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bulbs");

            migrationBuilder.DropTable(
                name: "BulbsHistory");

            migrationBuilder.DropTable(
                name: "DHTs");

            migrationBuilder.DropTable(
                name: "LightSensors");

            migrationBuilder.DropTable(
                name: "MotionSensors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Home");
        }
    }
}
