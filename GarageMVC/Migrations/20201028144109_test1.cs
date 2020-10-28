using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<int>(nullable: false),
                    LicenceNr = table.Column<string>(maxLength: 6, nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(maxLength: 15, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    NrOfWheels = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    StartLocation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceNr = table.Column<string>(maxLength: 6, nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(maxLength: 15, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    NrOfWheels = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    VehicleType2Id = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleType2s_VehicleType2Id",
                        column: x => x.VehicleType2Id,
                        principalTable: "VehicleType2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleSpots",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    SpotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpots", x => new { x.VehicleId, x.SpotId });
                    table.ForeignKey(
                        name: "FK_VehicleSpots_Spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "Spots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleSpots_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 3, "bill@gmail.com", "Billy", "Buch", null, "BBch" });

            migrationBuilder.InsertData(
                table: "VehicleType2s",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { 6, "Motorcycle", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MemberId",
                table: "Vehicles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleType2Id",
                table: "Vehicles",
                column: "VehicleType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpots_SpotId",
                table: "VehicleSpots",
                column: "SpotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "VehicleSpots");

            migrationBuilder.DropTable(
                name: "Spots");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "VehicleType2s");
        }
    }
}
