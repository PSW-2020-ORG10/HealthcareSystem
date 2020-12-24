using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "EmployeeId", "shiftId" },
                values: new object[] { 1, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "EmployeeId", "shiftId" },
                values: new object[] { 4, 1 });
        }
    }
}
