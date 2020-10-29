using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "VehicleType2Id",
                table: "Members",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleType2Id",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
