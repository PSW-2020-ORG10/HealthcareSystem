using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class NewScheduleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "id", "EmployeeId", "date", "isOnDuty", "room", "shiftId" },
                values: new object[] { 16, 1, "12/15/2020", true, "Ordination 1", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 16);
        }
    }
}
