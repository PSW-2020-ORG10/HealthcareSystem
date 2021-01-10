using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchMicroserviceApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    patientsid = table.Column<int>(nullable: false),
                    isUsed = table.Column<bool>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    typeOfRoom = table.Column<string>(nullable: true),
                    forUse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    doctorId = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    isConfirmed = table.Column<bool>(nullable: true),
                    PrescriptionId = table.Column<int>(nullable: true),
                    price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipment_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelEquipment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelEquipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_ModelEquipment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelMedicine",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelMedicine", x => x.id);
                    table.ForeignKey(
                        name: "FK_ModelMedicine_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modelRooms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelRooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_modelRooms_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity" },
                values: new object[] { 1, "Equipment", "Equipment name", 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "id", "DoctorId", "comment", "isUsed", "patientsid" },
                values: new object[,]
                {
                    { 5, 1, "Use every day", false, 1 },
                    { 6, 1, "When needed", true, 2 },
                    { 7, 2, "On every 12 hours", true, 1 },
                    { 8, 1, "After lunch", true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "id", "forUse", "typeOfRoom" },
                values: new object[] { 1, true, "typeOfRoom" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "PrescriptionId", "description", "doctorId", "isConfirmed" },
                values: new object[,]
                {
                    { 51, "Medicine", "Pancef", 44, 5, "For temperature", 1, false },
                    { 54, "Medicine", "Paracetamol", 4, 6, "For illness", 1, false },
                    { 52, "Medicine", "Defrinol", 2, 7, "For headache", 1, false },
                    { 53, "Medicine", "Brufen", 2, 8, "For illness", 1, false }
                });

            migrationBuilder.InsertData(
                table: "modelRooms",
                columns: new[] { "id", "Data", "EquipmentId" },
                values: new object[] { 1, "data", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PrescriptionId",
                table: "Equipment",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelEquipment_RoomId",
                table: "ModelEquipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelMedicine_RoomId",
                table: "ModelMedicine",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_modelRooms_EquipmentId",
                table: "modelRooms",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelEquipment");

            migrationBuilder.DropTable(
                name: "ModelMedicine");

            migrationBuilder.DropTable(
                name: "modelRooms");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
