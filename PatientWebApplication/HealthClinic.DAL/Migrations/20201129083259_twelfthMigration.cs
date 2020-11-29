using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class twelfthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "PharmacyAPI",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isRemoved",
                table: "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "PharmacyAPI",
                value: "12345");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyAPI",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "isRemoved",
                table: "Messages");

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "Messages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "isApproved",
                value: true);
        }
    }
}
