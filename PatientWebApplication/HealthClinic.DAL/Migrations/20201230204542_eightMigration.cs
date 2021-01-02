using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class eightMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenderId",
                table: "PharmacyTenderOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PharmacyTenderOffers",
                keyColumn: "id",
                keyValue: 1,
                column: "TenderId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "PharmacyTenderOffers");
        }
    }
}
