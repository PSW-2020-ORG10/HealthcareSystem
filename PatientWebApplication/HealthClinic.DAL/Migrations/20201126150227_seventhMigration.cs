using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_DoctorsOrders_DoctorsOrderid",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_DoctorsOrderid",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "DoctorsOrderid",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "date",
                table: "DoctorsOrders");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateEnd",
                table: "DoctorsOrders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateStart",
                table: "DoctorsOrders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isFinished",
                table: "DoctorsOrders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DoctorsOrders",
                keyColumn: "id",
                keyValue: 1,
                column: "isFinished",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateEnd",
                table: "DoctorsOrders");

            migrationBuilder.DropColumn(
                name: "dateStart",
                table: "DoctorsOrders");

            migrationBuilder.DropColumn(
                name: "isFinished",
                table: "DoctorsOrders");

            migrationBuilder.AddColumn<int>(
                name: "DoctorsOrderid",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "DoctorsOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_DoctorsOrderid",
                table: "Equipment",
                column: "DoctorsOrderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_DoctorsOrders_DoctorsOrderid",
                table: "Equipment",
                column: "DoctorsOrderid",
                principalTable: "DoctorsOrders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
