using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class EighthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "city", "dateOfBirth", "email", "firstName", "isSpecialist", "ordination", "password", "phoneNumber", "salary", "secondName", "speciality", "uniqueCitizensidentityNumber" },
                values: new object[] { 2, "Grad", "2/2/2020", "email", "Novak", false, "Ordination 1", "pass", "123", 200.0, "Maric", "Specialty", "12345" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "city", "dateOfBirth", "email", "firstName", "isSpecialist", "ordination", "password", "phoneNumber", "salary", "secondName", "speciality", "uniqueCitizensidentityNumber" },
                values: new object[] { 3, "Grad", "2/2/2020", "email", "Milica", false, "Ordination 1", "pass", "123", 200.0, "Tadic", "Specialty", "12346" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
