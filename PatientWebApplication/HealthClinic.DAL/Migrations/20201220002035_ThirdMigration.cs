using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                column: "file",
                value: "images.jfif");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3,
                column: "file",
                value: "download.jfif");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                column: "file",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3,
                column: "file",
                value: null);
        }
    }
}
