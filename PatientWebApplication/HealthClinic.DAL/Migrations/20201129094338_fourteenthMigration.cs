using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class fourteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyAPI",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "PharmacyName",
                table: "Messages",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "PharmacyName",
                value: "Apoteka Jankovic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyName",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "PharmacyAPI",
                table: "Messages",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "PharmacyAPI",
                value: "12345");
        }
    }
}
