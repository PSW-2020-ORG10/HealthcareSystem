using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class ThreetenMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Registrations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "town",
                table: "Registrations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "apiKey", "name", "town" },
                values: new object[] { "api1789", "Jankovic 1", "Novi Sad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "town",
                table: "Registrations");

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "id",
                keyValue: 1,
                column: "apiKey",
                value: "Api key");
        }
    }
}
