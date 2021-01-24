using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchMicroserviceApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Patientsid = table.Column<int>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DoctorId = table.Column<int>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeOfRoom = table.Column<string>(nullable: true),
                    ForUse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "modelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modelRooms_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescribedMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    HowToUse = table.Column<string>(nullable: true),
                    PrescriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescribedMedicines_Equipment_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescribedMedicines_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelEquipment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelMedicine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelMedicine_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Discriminator", "Name", "Quantity" },
                values: new object[] { 100, "Equipment", "Equipment name", 1 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Discriminator", "Name", "Quantity", "Description" },
                values: new object[,]
                {
                    { 1, "Medicine", "Pancef 300mg", 44, "For temperature" },
                    { 2, "Medicine", "Defrinol 100mg", 2, "For headache" },
                    { 3, "Medicine", "Brufen 200mg", 2, "For illness" },
                    { 4, "Medicine", "Paracetamol 200mg", 4, "For temperature" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentId", "Comment", "DoctorId", "IsUsed", "Patientsid" },
                values: new object[,]
                {
                    { 14, 14, "After finishing treatment, schedule control appointment.", 1, true, 2 },
                    { 13, 13, "In case of allergy, stop taking medicine immediately.", 1, false, 1 },
                    { 12, 12, "If illnness stops, stop taking medicine.", 2, true, 1 },
                    { 11, 11, "After finishing treatment, schedule control appointment.", 1, true, 2 },
                    { 10, 10, "In case of allergy, stop taking medicine immediately.", 1, false, 1 },
                    { 9, 9, "If illnness stops, stop taking medicine.", 2, true, 1 },
                    { 8, 8, "After finishing treatment, schedule control appointment.", 1, true, 2 },
                    { 6, 6, "If illnness stops, stop taking medicine.", 2, true, 1 },
                    { 15, 15, "If illnness stops, stop taking medicine.", 2, true, 1 },
                    { 5, 5, "After finishing treatment, schedule control appointment.", 1, true, 2 },
                    { 4, 4, "In case of allergy, stop taking medicine immediately.", 1, false, 1 },
                    { 3, 3, "If illnness stops, stop taking medicine.", 2, true, 1 },
                    { 2, 2, "After finishing treatment, schedule control appointment.", 1, true, 2 },
                    { 1, 1, "In case of allergy, stop taking medicine immediately.", 1, false, 1 },
                    { 7, 7, "In case of allergy, stop taking medicine immediately.", 1, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ForUse", "TypeOfRoom" },
                values: new object[] { 1, true, "typeOfRoom" });

            migrationBuilder.InsertData(
                table: "PrescribedMedicines",
                columns: new[] { "Id", "HowToUse", "MedicineId", "PrescriptionId", "Quantity" },
                values: new object[,]
                {
                    { 18, "Every 12 hours.", 3, 4, 3 },
                    { 8, "Take one when body temperature exceedes 39 degrees", 4, 6, 4 },
                    { 7, "Every 12 hours.", 3, 6, 3 },
                    { 6, "Whenever headache reapers", 2, 6, 2 },
                    { 5, "Every 8 hours", 1, 6, 1 },
                    { 4, "Take one when body temperature exceedes 39 degrees", 4, 5, 4 },
                    { 3, "Every 12 hours.", 3, 5, 3 },
                    { 2, "Whenever headache reapers", 2, 5, 2 },
                    { 1, "Every 8 hours", 1, 5, 1 },
                    { 19, "Every 12 hours.", 3, 7, 3 },
                    { 20, "Every 8 hours", 1, 7, 1 },
                    { 16, "Every 8 hours", 1, 4, 1 },
                    { 15, "Every 12 hours.", 3, 3, 3 },
                    { 14, "Whenever headache reapers", 2, 3, 2 },
                    { 13, "Every 8 hours", 1, 3, 1 },
                    { 12, "Whenever headache reapers", 2, 2, 2 },
                    { 11, "Every 8 hours", 1, 2, 1 },
                    { 10, "Every 12 hours.", 3, 1, 3 },
                    { 9, "Take one when body temperature exceedes 39 degrees", 2, 1, 4 },
                    { 17, "Whenever headache reapers", 2, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "modelRooms",
                columns: new[] { "Id", "Data", "EquipmentId" },
                values: new object[] { 1, "data", 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicines_MedicineId",
                table: "PrescribedMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicines_PrescriptionId",
                table: "PrescribedMedicines",
                column: "PrescriptionId");
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
                name: "PrescribedMedicines");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
