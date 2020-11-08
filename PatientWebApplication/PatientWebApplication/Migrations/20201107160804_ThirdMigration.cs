using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWebApplication.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Feedbacks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Feedbacks");
        }
    }
}
