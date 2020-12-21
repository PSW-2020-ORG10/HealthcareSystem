using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "id", "endTime", "startTime" },
                values: new object[] { 4, "23:00", "08:00" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 12,
                column: "shiftId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "id", "EmployeeId", "date", "isOnDuty", "room", "shiftId" },
                values: new object[] { 12, 1, "19/12/2020", true, "Ordination 1", 3 });
        }
    }
}
