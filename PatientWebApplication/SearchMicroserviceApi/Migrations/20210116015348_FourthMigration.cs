using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchMicroserviceApi.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "HowToUse",
                value: "Take one when body temperature exceedes 39 degrees");

            migrationBuilder.UpdateData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "HowToUse",
                value: "Take one when body temperature exceedes 39 degrees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "HowToUse",
                value: "When body temperature exceedes 39 degrees");

            migrationBuilder.UpdateData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "HowToUse",
                value: "When body temperature exceedes 39 degrees");
        }
    }
}
