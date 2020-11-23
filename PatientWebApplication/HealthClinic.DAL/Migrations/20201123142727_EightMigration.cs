using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class EightMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "id", "DoctorId", "comment", "isUsed", "patientsid" },
                values: new object[] { 3, 1, "Every 12 hours", true, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "id", "DoctorId", "comment", "isUsed", "patientsid" },
                values: new object[] { 4, 1, "When needed", false, 1 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "DoctorsOrderid", "FinishedOrderid", "PharmacyOfferid", "PrescriptionId", "description", "doctorId", "isConfirmed" },
                values: new object[] { 23, "Medicine", "Panklav", 2, null, null, null, 3, "For cold", 1, false });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "DoctorsOrderid", "FinishedOrderid", "PharmacyOfferid", "PrescriptionId", "description", "doctorId", "isConfirmed" },
                values: new object[] { 24, "Medicine", "Defrinol", 2, null, null, null, 4, "For headache", 1, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
