using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "allergie", "city", "dateOfBirth", "email", "firstName", "guest", "isRegisteredBySecretary", "medicalIdNumber", "password", "phoneNumber", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 2, "Alergija", "Grad", "2/2/2020", "email", "Mika", false, false, "3322", "pass", "333", "Mikic", "3322" });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "id", "comment", "isUsed", "patientsid" },
                values: new object[] { 2, "Some text", true, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
