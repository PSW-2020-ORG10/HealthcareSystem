using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Patients",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "exLastname", "medicalIdNumber" },
                values: new object[] { "", "212313" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "exLastname", "medicalIdNumber" },
                values: new object[] { "", "2112313" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "exLastname", "medicalIdNumber" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "exLastname", "medicalIdNumber" },
                values: new object[] { null, null });
        }
    }
}
