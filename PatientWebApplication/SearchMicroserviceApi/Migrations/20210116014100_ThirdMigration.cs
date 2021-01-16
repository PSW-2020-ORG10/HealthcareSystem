using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchMicroserviceApi.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppointmentId", "HowToUse", "IsUsed", "Patientsid" },
                values: new object[] { 5, "After finishing treatment, schedule control appointment.", true, 2 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AppointmentId", "DoctorId", "HowToUse", "Patientsid" },
                values: new object[] { 6, 2, "If illnness stops, stop taking medicine.", 1 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AppointmentId", "DoctorId", "HowToUse", "IsUsed" },
                values: new object[] { 7, 1, "In case of allergy, stop taking medicine immediately.", false });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentId", "DoctorId", "HowToUse", "IsUsed", "Patientsid" },
                values: new object[,]
                {
                    { 1, 1, 1, "In case of allergy, stop taking medicine immediately.", false, 1 },
                    { 2, 2, 1, "After finishing treatment, schedule control appointment.", true, 2 },
                    { 3, 3, 2, "If illnness stops, stop taking medicine.", true, 1 },
                    { 4, 4, 1, "In case of allergy, stop taking medicine immediately.", false, 1 },
                    { 8, 8, 1, "After finishing treatment, schedule control appointment.", true, 2 },
                    { 9, 9, 2, "If illnness stops, stop taking medicine.", true, 1 },
                    { 10, 10, 1, "In case of allergy, stop taking medicine immediately.", false, 1 },
                    { 11, 11, 1, "After finishing treatment, schedule control appointment.", true, 2 },
                    { 12, 12, 2, "If illnness stops, stop taking medicine.", true, 1 },
                    { 13, 13, 1, "In case of allergy, stop taking medicine immediately.", false, 1 },
                    { 14, 14, 1, "After finishing treatment, schedule control appointment.", true, 2 },
                    { 15, 15, 2, "If illnness stops, stop taking medicine.", true, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppointmentId", "HowToUse", "IsUsed", "Patientsid" },
                values: new object[] { 1, "In case of allergy, stop taking medicine immediately.", false, 1 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AppointmentId", "DoctorId", "HowToUse", "Patientsid" },
                values: new object[] { 2, 1, "After finishing treatment, schedule control appointment.", 2 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AppointmentId", "DoctorId", "HowToUse", "IsUsed" },
                values: new object[] { 3, 2, "If illnness stops, stop taking medicine.", true });
        }
    }
}
