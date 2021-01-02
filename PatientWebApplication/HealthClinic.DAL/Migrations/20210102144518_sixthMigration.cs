using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_FinishedOrders_FinishedOrderid",
                table: "Equipment");

            migrationBuilder.DropTable(
                name: "FinishedOrders");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_FinishedOrderid",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "FinishedOrderid",
                table: "Equipment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinishedOrderid",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinishedOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedOrders", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "FinishedOrders",
                column: "id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_FinishedOrderid",
                table: "Equipment",
                column: "FinishedOrderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_FinishedOrders_FinishedOrderid",
                table: "Equipment",
                column: "FinishedOrderid",
                principalTable: "FinishedOrders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
