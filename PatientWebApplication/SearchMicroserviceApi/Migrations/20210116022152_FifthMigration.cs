using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchMicroserviceApi.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowToUse",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Comment",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Comment",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Comment",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Comment",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Comment",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Comment",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Comment",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Comment",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Comment",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Comment",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Comment",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Comment",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Comment",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Comment",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Comment",
                value: "If illnness stops, stop taking medicine.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "HowToUse",
                table: "Prescriptions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "HowToUse",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "HowToUse",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "HowToUse",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "HowToUse",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "HowToUse",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "HowToUse",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "HowToUse",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "HowToUse",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "HowToUse",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "HowToUse",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "HowToUse",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "HowToUse",
                value: "If illnness stops, stop taking medicine.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "HowToUse",
                value: "In case of allergy, stop taking medicine immediately.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "HowToUse",
                value: "After finishing treatment, schedule control appointment.");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "HowToUse",
                value: "If illnness stops, stop taking medicine.");
        }
    }
}
