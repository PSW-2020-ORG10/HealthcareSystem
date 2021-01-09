using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3,
                column: "isVerified",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3,
                column: "isVerified",
                value: false);
        }
    }
}
