using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 22,
                column: "Date",
                value: "16/01/2021");

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Date", "EmployeeId", "IsOnDuty", "Room", "ShiftId" },
                values: new object[,]
                {
                    { 23, "17/01/2021", 1, true, "Ordination 1", 3 },
                    { 24, "18/01/2021", 1, true, "Ordination 1", 3 },
                    { 25, "19/01/2021", 1, true, "Ordination 1", 4 },
                    { 26, "20/01/2021", 1, true, "Ordination 1", 3 },
                    { 27, "21/01/2021", 1, true, "Ordination 1", 3 },
                    { 28, "22/01/2021", 1, true, "Ordination 1", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 22,
                column: "Date",
                value: "29/12/2020");
        }
    }
}
