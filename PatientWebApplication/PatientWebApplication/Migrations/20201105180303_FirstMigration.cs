using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWebApplication.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    secondName = table.Column<string>(nullable: true),
                    uniqueCitizensidentityNumber = table.Column<string>(nullable: true),
                    dateOfBirth = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    salary = table.Column<double>(nullable: false),
                    city = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    isSpecialist = table.Column<bool>(nullable: false),
                    ordination = table.Column<string>(nullable: true),
                    speciality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    secondName = table.Column<string>(nullable: true),
                    uniqueCitizensidentityNumber = table.Column<string>(nullable: true),
                    dateOfBirth = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    medicalIdNumber = table.Column<string>(nullable: true),
                    allergie = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    guest = table.Column<bool>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    isRegisteredBySecretary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    medicine = table.Column<string>(nullable: true),
                    takeMedicineUntil = table.Column<string>(nullable: true),
                    quantityPerDay = table.Column<int>(nullable: false),
                    classify = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Renovation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    room = table.Column<string>(nullable: true),
                    startDate = table.Column<string>(nullable: true),
                    endDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    startTime = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorNotifications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    DoctorUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorNotifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorNotifications_Doctors_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipment_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsAnonymous = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientNotifications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    PatientUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientNotifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_PatientNotifications_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientUserId = table.Column<int>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    start = table.Column<TimeSpan>(nullable: false),
                    end = table.Column<TimeSpan>(nullable: false),
                    DoctorUserId = table.Column<int>(nullable: false),
                    idRoom = table.Column<string>(nullable: true),
                    OperationReferralId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Operations_Doctors_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_Referral_OperationReferralId",
                        column: x => x.OperationReferralId,
                        principalTable: "Referral",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    employeeFirst = table.Column<string>(nullable: true),
                    employeeLast = table.Column<string>(nullable: true),
                    employeeid = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    isOnDuty = table.Column<bool>(nullable: false),
                    shiftId = table.Column<int>(nullable: false),
                    room = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_Schedule_Shift_shiftId",
                        column: x => x.shiftId,
                        principalTable: "Shift",
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
                table: "Doctors",
                columns: new[] { "id", "city", "dateOfBirth", "email", "firstName", "isSpecialist", "ordination", "password", "phoneNumber", "salary", "secondName", "speciality", "uniqueCitizensidentityNumber" },
                values: new object[] { 1, "Grad", "2/2/2020", "email", "DoctorName", false, "Ordination 1", "pass", "123", 200.0, "DoctorSurname", "Specialty", "1234" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity" },
                values: new object[] { 1, "Equipment", "Equipment name", 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "allergie", "city", "dateOfBirth", "email", "firstName", "guest", "isRegisteredBySecretary", "medicalIdNumber", "password", "phoneNumber", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 1, "Alergija", "Grad", "2/2/2020", "email", "Pera", false, false, "1234", "pass", "123", "Peric", "1234" });

            migrationBuilder.InsertData(
                table: "Referral",
                columns: new[] { "id", "classify", "comment", "medicine", "quantityPerDay", "takeMedicineUntil" },
                values: new object[] { 1, "classify", "comment", "Medicine", 3, "Take medicine until" });

            migrationBuilder.InsertData(
                table: "Renovation",
                columns: new[] { "id", "endDate", "room", "startDate" },
                values: new object[] { 1, "End Date", "1", "Start date" });

            migrationBuilder.InsertData(
                table: "Shift",
                columns: new[] { "id", "endTime", "startTime" },
                values: new object[] { 1, "End time", "Start time" });

            migrationBuilder.InsertData(
                table: "DoctorNotifications",
                columns: new[] { "id", "Data", "DoctorUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "description", "doctorId", "isConfirmed", "price" },
                values: new object[] { 13, "OfferedMedicines", "OfferedMedicine", 2, "description", 1, false, 10.0 });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "id", "IsAnonymous", "IsPublic", "IsPublished", "Message", "PatientId" },
                values: new object[,]
                {
                    { 1, true, true, false, "First message", 1 },
                    { 2, false, false, false, "Second message", 1 },
                    { 3, false, true, false, "Third message", 1 }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "id", "DoctorUserId", "OperationReferralId", "PatientUserId", "date", "end", "idRoom", "start" },
                values: new object[] { 1, 1, 1, 1, "2/2/2020", new TimeSpan(0, 0, 0, 0, 0), "room1", new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "PatientNotifications",
                columns: new[] { "id", "Data", "PatientUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "id", "date", "employeeFirst", "employeeLast", "employeeid", "isOnDuty", "room", "shiftId" },
                values: new object[] { 1, "2/2/2020", "EmployeeName", "EmployeeSurname", "1", false, "1", 1 });

            migrationBuilder.InsertData(
                table: "modelRooms",
                columns: new[] { "id", "Data", "EquipmentId" },
                values: new object[] { 1, "data", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNotifications_DoctorUserId",
                table: "DoctorNotifications",
                column: "DoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_doctorId",
                table: "Equipment",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_modelRooms_EquipmentId",
                table: "modelRooms",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_DoctorUserId",
                table: "Operations",
                column: "DoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationReferralId",
                table: "Operations",
                column: "OperationReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PatientUserId",
                table: "Operations",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNotifications_PatientUserId",
                table: "PatientNotifications",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_shiftId",
                table: "Schedule",
                column: "shiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorNotifications");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "modelRooms");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "PatientNotifications");

            migrationBuilder.DropTable(
                name: "Renovation");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
