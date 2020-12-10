using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "allergie", "bornIn", "city", "dateOfBirth", "email", "exLastname", "file", "firstName", "gender", "guest", "isBlocked", "isMarried", "isRegisteredBySecretary", "isVerified", "medicalIdNumber", "parentName", "password", "phoneNumber", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 3, "Alergija", "Grad2", "Grad", "2/2/2020", "email", "", null, "Stefan", "Male", false, false, false, false, false, "212313", "Roditelj", "pass", "123", "Lelic", "1234" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "allergie", "bornIn", "city", "dateOfBirth", "email", "exLastname", "file", "firstName", "gender", "guest", "isBlocked", "isMarried", "isRegisteredBySecretary", "isVerified", "medicalIdNumber", "parentName", "password", "phoneNumber", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 4, "Alergija", "Grad2", "Grad", "2/2/2020", "email", "", null, "Marko", "Female", false, false, false, false, false, "2112313", "Roditelj", "pass", "123", "Lazarevic", "1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
