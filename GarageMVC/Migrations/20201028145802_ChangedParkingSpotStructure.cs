using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class ChangedParkingSpotStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleSpots");

            migrationBuilder.AddColumn<int>(
                name: "SpotNr",
                table: "Spots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Spots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spots_VehicleId",
                table: "Spots",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spots_Vehicles_VehicleId",
                table: "Spots",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spots_Vehicles_VehicleId",
                table: "Spots");

            migrationBuilder.DropIndex(
                name: "IX_Spots_VehicleId",
                table: "Spots");

            migrationBuilder.DropColumn(
                name: "SpotNr",
                table: "Spots");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Spots");

            migrationBuilder.CreateTable(
                name: "VehicleSpots",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    SpotId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpots_SpotId",
                table: "VehicleSpots",
                column: "SpotId");
        }
    }
}
