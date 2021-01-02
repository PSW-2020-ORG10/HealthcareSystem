using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_PharmacyOffers_PharmacyOfferid",
                table: "Equipment");

            migrationBuilder.DropTable(
                name: "PharmacyOffers");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_PharmacyOfferid",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "PharmacyOfferid",
                table: "Equipment");

            migrationBuilder.CreateTable(
                name: "MedicineTenderOffers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PharmacyTenderOfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTenderOffers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineWithQuantities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineWithQuantities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyTenderOffers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PharmacyApi = table.Column<string>(nullable: true),
                    IsWinner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyTenderOffers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "MedicineTenderOffers",
                columns: new[] { "id", "AvailableQuantity", "MedicineName", "PharmacyTenderOfferId", "Price", "Quantity" },
                values: new object[] { 1, 1, "Andol", 1, 1.0, 1 });

            migrationBuilder.InsertData(
                table: "MedicineWithQuantities",
                columns: new[] { "id", "Name", "Quantity" },
                values: new object[] { 1, "Andol", 1 });

            migrationBuilder.InsertData(
                table: "PharmacyTenderOffers",
                columns: new[] { "id", "IsWinner", "PharmacyApi" },
                values: new object[] { 1, false, "pharmacyApi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineTenderOffers");

            migrationBuilder.DropTable(
                name: "MedicineWithQuantities");

            migrationBuilder.DropTable(
                name: "PharmacyTenderOffers");

            migrationBuilder.AddColumn<int>(
                name: "PharmacyOfferid",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PharmacyOffers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PharmacyName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SummPriceOfMedications = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyOffers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "PharmacyOffers",
                columns: new[] { "id", "PharmacyName", "SummPriceOfMedications" },
                values: new object[] { 1, "pharmacyName", 100.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PharmacyOfferid",
                table: "Equipment",
                column: "PharmacyOfferid");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_PharmacyOffers_PharmacyOfferid",
                table: "Equipment",
                column: "PharmacyOfferid",
                principalTable: "PharmacyOffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
