using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Patients",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "exLastname", "gender" },
                values: new object[] { null, "Male" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "exLastname", "gender" },
                values: new object[] { null, "Female" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1,
                column: "exLastname",
                value: "");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2,
                column: "exLastname",
                value: "");
        }
    }
}
