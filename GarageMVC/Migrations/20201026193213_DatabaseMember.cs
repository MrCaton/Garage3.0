using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class DatabaseMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "ParkedVehicle",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
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
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { 1, "nelsonmandela@gmail.com", "Nelson", "Mandela", "Nmandela" });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 25, 20, 32, 12, 797, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 25, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 24, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 23, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 22, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 21, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 20, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 19, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 17, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_MemberId",
                table: "ParkedVehicle",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_Member_MemberId",
                table: "ParkedVehicle",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_Member_MemberId",
                table: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_MemberId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "ParkedVehicle");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 21, 21, 46, 896, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 17, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 16, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3332));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 15, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 14, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 13, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 12, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 11, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 10, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3386));
        }
    }
}
