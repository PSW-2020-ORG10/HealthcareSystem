using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class PatientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "file", "isVerified" },
                values: new object[] { "download.jfif", true });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                column: "isVerified",
                value: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 4,
                column: "file",
                value: "download.jfif");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "file", "isVerified" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                column: "isVerified",
                value: false);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 4,
                column: "file",
                value: null);
        }
    }
}
