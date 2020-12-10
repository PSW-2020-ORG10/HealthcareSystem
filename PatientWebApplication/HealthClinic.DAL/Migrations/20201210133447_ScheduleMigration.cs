using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class ScheduleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "id", "EmployeeId", "date", "isOnDuty", "room", "shiftId" },
                values: new object[,]
                {
                    { 7, 1, "14/12/2020", true, "Ordination 1", 3 },
                    { 8, 1, "15/12/2020", true, "Ordination 1", 3 },
                    { 9, 1, "16/12/2020", true, "Ordination 1", 3 },
                    { 10, 1, "17/12/2020", true, "Ordination 1", 3 },
                    { 11, 1, "18/12/2020", true, "Ordination 1", 3 },
                    { 12, 1, "19/12/2020", true, "Ordination 1", 3 },
                    { 13, 1, "20/12/2020", true, "Ordination 1", 3 },
                    { 14, 1, "21/12/2020", true, "Ordination 1", 3 },
                    { 15, 1, "22/12/2020", true, "Ordination 1", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 15);
        }
    }
}
