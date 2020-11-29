using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class FourteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "id",
                keyValue: 1,
                column: "apiKey",
                value: "api1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "id",
                keyValue: 1,
                column: "apiKey",
                value: "api1789");
        }
    }
}
