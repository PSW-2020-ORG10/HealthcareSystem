using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "id", "EmployeeId", "date", "isOnDuty", "room", "shiftId" },
                values: new object[] { 22, 1, "29/12/2020", true, "1", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 22);
        }
    }
}
