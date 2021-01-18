using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineInformationApi.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDescriptions",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MedicineInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDescriptions", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MedicineDescriptions_MedicineInformations_MedicineInformatio~",
                        column: x => x.MedicineInformationId,
                        principalTable: "MedicineInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MedicineInformations",
                columns: new[] { "Id", "Quantity" },
                values: new object[,]
                {
                    { 1, 150 },
                    { 2, 100 },
                    { 3, 44 },
                    { 4, 33 }
                });

            migrationBuilder.InsertData(
                table: "MedicineDescriptions",
                columns: new[] { "Name", "Description", "MedicineInformationId" },
                values: new object[,]
                {
                    { "Paracetamol", "Paracetamol is a nonsteroidal anti-inflammatory drug (NSAID) used to treat mild-to-moderate pain, and helps to relieve symptoms of arthritis.", 1 },
                    { "Brufen", "Brufen is used to reduce fever and relieve mild to moderate pain.", 2 },
                    { "Defrinol", "Defrinol is used to treat certain types of bacterial infections.", 3 },
                    { "Pancef", "Pancef is indicated for: Headache, Colds & Influenza, Backache, Period Pain, Pain of Osteoarthritis, Muscle Pain, Toothache, Rheumatic Pain", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDescriptions_MedicineInformationId",
                table: "MedicineDescriptions",
                column: "MedicineInformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineDescriptions");

            migrationBuilder.DropTable(
                name: "MedicineInformations");
        }
    }
}
