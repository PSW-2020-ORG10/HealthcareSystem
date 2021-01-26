using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Date", "EmployeeId", "IsOnDuty", "Room", "ShiftId" },
                values: new object[,]
                {
                    { 31, "26/01/2021", 1, true, "Ordination 1", 3 },
                    { 32, "27/01/2021", 1, true, "Ordination 1", 3 },
                    { 33, "28/01/2021", 1, true, "Ordination 1", 4 },
                    { 34, "29/01/2021", 1, true, "Ordination 1", 3 },
                    { 35, "30/01/2021", 1, true, "Ordination 1", 3 },
                    { 36, "31/01/2021", 1, true, "Ordination 1", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 36);
        }
    }
}
