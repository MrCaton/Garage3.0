using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class Init : Migration
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
                    UserName = table.Column<string>(nullable: true)
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
                name: "Spots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotNr = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spots_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "UserName" },
                values: new object[,]
                {
                    { 1, "bill@gmail.com", "Billy", "Buch", "BBch" },
                    { 2, "ivan@gmail.com", "Ivan", "Araque", "MrCaton" },
                    { 3, "david@gmail.com", "David", "Nokto", "D.Nokto" },
                    { 4, "mats@gmail.com", "Mats", "Nilsson", "Matslearning" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType2s",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[,]
                {
                    { 1, "Motorcycle", 1 },
                    { 2, "Car", 1 },
                    { 3, "Bus", 2 },
                    { 4, "Airplane", 3 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "LicenceNr", "MemberId", "Model", "NrOfWheels", "VehicleType2Id" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 10, 28, 13, 26, 36, 987, DateTimeKind.Local).AddTicks(8196), "Yamaha", "Black", "SKTHMH", 3, "Super", 2, 1 },
                    { 1, new DateTime(2020, 10, 23, 13, 26, 36, 979, DateTimeKind.Local).AddTicks(6786), "Opel", "Green", "CARBBC", 1, "Corsa", 4, 2 },
                    { 2, new DateTime(2020, 10, 25, 13, 26, 36, 987, DateTimeKind.Local).AddTicks(8037), "Volvo", "Black", "NAVI94", 2, "XC90", 4, 2 },
                    { 4, new DateTime(2020, 10, 29, 13, 26, 36, 987, DateTimeKind.Local).AddTicks(8211), "Mercedes", "Blue", "BUSBUS", 4, "Ultra", 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spots_VehicleId",
                table: "Spots",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MemberId",
                table: "Vehicles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleType2Id",
                table: "Vehicles",
                column: "VehicleType2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");

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
