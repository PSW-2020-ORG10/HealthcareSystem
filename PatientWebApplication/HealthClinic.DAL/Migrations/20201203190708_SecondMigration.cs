using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "id", "EmployeeId", "date", "isOnDuty", "room", "shiftId" },
                values: new object[,]
                {
                    { 6, 1, "08/12/2020", true, "Ordination 1", 1 },
                    { 7, 1, "09/12/2020", true, "Ordination 1", 1 },
                    { 8, 1, "10/12/2020", true, "Ordination 1", 1 },
                    { 9, 1, "11/12/2020", true, "Ordination 1", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "id",
                keyValue: 6);

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
        }
    }
}
