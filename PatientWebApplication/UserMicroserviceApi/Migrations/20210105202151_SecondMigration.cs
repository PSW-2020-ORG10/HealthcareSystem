using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "id", "Discriminator", "city", "dateOfBirth", "email", "firstName", "password", "phoneNumber", "salary", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[,]
                {
                    { 5, "Administrator", "Grad", "12/12/1985", "admin1@gmail.com", "Pera", "password", "123", 133.0, "Peric", "1234" },
                    { 6, "Administrator", "Grad", "12/12/1985", "admin2@gmail.com", "Ana", "password", "123", 133.0, "Stanic", "1234" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email", "password" },
                values: new object[] { "patient1@gmail.com", "12345" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "12345");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "email", "password" },
                values: new object[] { "patient2@gmail.com", "12345" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "email", "password" },
                values: new object[] { "patient2@gmail.com", "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeUser",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeUser",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email", "password" },
                values: new object[] { "email", "pass" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "pass");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "email", "password" },
                values: new object[] { "email", "pass" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "email", "password" },
                values: new object[] { "email", "pass" });
        }
    }
}
