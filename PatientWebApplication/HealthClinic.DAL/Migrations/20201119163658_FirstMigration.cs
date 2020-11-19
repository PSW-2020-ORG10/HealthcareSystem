using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
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
                name: "FinishedOrders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ManagersOrders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    isUrgent = table.Column<bool>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    isOrdered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagersOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ManagerUsers",
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
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerUsers", x => x.id);
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
                    isVerified = table.Column<bool>(nullable: false),
                    allergie = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    guest = table.Column<bool>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    isRegisteredBySecretary = table.Column<bool>(nullable: false),
                    isMarried = table.Column<bool>(nullable: false),
                    bornIn = table.Column<string>(nullable: true),
                    parentName = table.Column<string>(nullable: true),
                    exLastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyOffers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pharmacyName = table.Column<string>(nullable: true),
                    summPriceOfMedications = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyOffers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    patientsid = table.Column<int>(nullable: false),
                    isUsed = table.Column<bool>(nullable: false),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
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
                name: "SecretaryUsers",
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
                    room = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretaryUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    startTime = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.id);
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
                name: "DoctorsOrders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    isUrgent = table.Column<bool>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    isOrdered = table.Column<bool>(nullable: false),
                    ManagersOrderid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorsOrders_ManagersOrders_ManagersOrderid",
                        column: x => x.ManagersOrderid,
                        principalTable: "ManagersOrders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerNotification",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    ManagerUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerNotification", x => x.id);
                    table.ForeignKey(
                        name: "FK_ManagerNotification_ManagerUsers_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "ManagerUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorAppointments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    doctorUserId = table.Column<int>(nullable: false),
                    time = table.Column<TimeSpan>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    patientUserId = table.Column<int>(nullable: false),
                    roomid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAppointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorAppointments_Doctors_doctorUserId",
                        column: x => x.doctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorAppointments_Patients_patientUserId",
                        column: x => x.patientUserId,
                        principalTable: "Patients",
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
                    Date = table.Column<DateTime>(nullable: false),
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
                name: "Schedules",
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
                    table.PrimaryKey("PK_Schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_Schedules_Shifts_shiftId",
                        column: x => x.shiftId,
                        principalTable: "Shifts",
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
                    PrescriptionId = table.Column<int>(nullable: true),
                    DoctorsOrderid = table.Column<int>(nullable: true),
                    FinishedOrderid = table.Column<int>(nullable: true),
                    PharmacyOfferid = table.Column<int>(nullable: true),
                    price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipment_DoctorsOrders_DoctorsOrderid",
                        column: x => x.DoctorsOrderid,
                        principalTable: "DoctorsOrders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_FinishedOrders_FinishedOrderid",
                        column: x => x.FinishedOrderid,
                        principalTable: "FinishedOrders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_PharmacyOffers_PharmacyOfferid",
                        column: x => x.PharmacyOfferid,
                        principalTable: "PharmacyOffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referrals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    medicine = table.Column<string>(nullable: true),
                    takeMedicineUntil = table.Column<string>(nullable: true),
                    quantityPerDay = table.Column<int>(nullable: false),
                    classify = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    DoctorAppointmentid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Referrals_DoctorAppointments_DoctorAppointmentid",
                        column: x => x.DoctorAppointmentid,
                        principalTable: "DoctorAppointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Operations_Referrals_OperationReferralId",
                        column: x => x.OperationReferralId,
                        principalTable: "Referrals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "city", "dateOfBirth", "email", "firstName", "isSpecialist", "ordination", "password", "phoneNumber", "salary", "secondName", "speciality", "uniqueCitizensidentityNumber" },
                values: new object[] { 1, "Grad", "2/2/2020", "email", "DoctorName", false, "Ordination 1", "pass", "123", 200.0, "DoctorSurname", "Specialty", "1234" });

            migrationBuilder.InsertData(
                table: "DoctorsOrders",
                columns: new[] { "id", "ManagersOrderid", "date", "isOrdered", "isUrgent" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity" },
                values: new object[] { 1, "Equipment", "Equipment name", 1 });

            migrationBuilder.InsertData(
                table: "FinishedOrders",
                column: "id",
                value: 1);

            migrationBuilder.InsertData(
                table: "ManagerUsers",
                columns: new[] { "id", "city", "dateOfBirth", "email", "firstName", "password", "phoneNumber", "salary", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 17, "Grad", "22/04/1993", "email", "Manager Name", "pass", "123", 200.0, "Manager Surname", "1234" });

            migrationBuilder.InsertData(
                table: "ManagersOrders",
                columns: new[] { "id", "date", "isOrdered", "isUrgent" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "allergie", "bornIn", "city", "dateOfBirth", "email", "exLastname", "firstName", "guest", "isMarried", "isRegisteredBySecretary", "isVerified", "medicalIdNumber", "parentName", "password", "phoneNumber", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[,]
                {
                    { 1, "Alergija", "Grad2", "Grad", "2/2/2020", "email", "", "Pera2", false, false, false, false, "1234", "Roditelj", "pass", "123", "Peric", "1234" },
                    { 2, "Alergija", "Grad2", "Grad", "2/2/2020", "email", "", "Pera3", false, false, false, false, "1234", "Roditelj", "pass", "123", "Peric", "1234" }
                });

            migrationBuilder.InsertData(
                table: "PharmacyOffers",
                columns: new[] { "id", "pharmacyName", "summPriceOfMedications" },
                values: new object[] { 1, "pharmacyName", 100.0 });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "id", "name", "number" },
                values: new object[] { 1, "Name", 123 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "id", "comment", "isUsed", "patientsid" },
                values: new object[,]
                {
                    { 1, "Comment", true, 1 },
                    { 2, "Some text", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "id", "answer", "name" },
                values: new object[] { 1, "Answer", "Name" });

            migrationBuilder.InsertData(
                table: "Referrals",
                columns: new[] { "id", "DoctorAppointmentid", "classify", "comment", "medicine", "quantityPerDay", "takeMedicineUntil" },
                values: new object[] { 1, null, "classify", "comment", "Medicine", 3, "Take medicine until" });

            migrationBuilder.InsertData(
                table: "Renovation",
                columns: new[] { "id", "endDate", "room", "startDate" },
                values: new object[] { 1, "End Date", "1", "Start date" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "id", "forUse", "typeOfRoom" },
                values: new object[] { 1, true, "typeOfRoom" });

            migrationBuilder.InsertData(
                table: "SecretaryUsers",
                columns: new[] { "id", "city", "dateOfBirth", "email", "firstName", "password", "phoneNumber", "room", "salary", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 1, "Grad", "12/12/2012", "email", "Secretary Name", "pass", "123", "Room", 133.0, "Secretary Surname", "1234" });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "id", "endTime", "startTime" },
                values: new object[] { 1, "End time", "Start time" });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "date", "doctorUserId", "patientUserId", "roomid", "time" },
                values: new object[] { 1, "22/04/2020", 1, 2, "1", new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "DoctorNotifications",
                columns: new[] { "id", "Data", "DoctorUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "DoctorsOrderid", "FinishedOrderid", "PharmacyOfferid", "PrescriptionId", "description", "doctorId", "isConfirmed" },
                values: new object[] { 22, "Medicine", "Medicine Name", 2, null, null, null, 1, "Medicine Description", 1, false });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "DoctorsOrderid", "FinishedOrderid", "PharmacyOfferid", "PrescriptionId", "description", "doctorId", "isConfirmed", "price" },
                values: new object[] { 13, "OfferedMedicines", "OfferedMedicine", 2, null, null, null, 1, "description", 1, false, 10.0 });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "id", "Date", "IsAnonymous", "IsPublic", "IsPublished", "Message", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, "First message", 1 },
                    { 2, new DateTime(2019, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Second message", 1 },
                    { 3, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Third message", 1 },
                    { 4, new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Fourth message", 1 }
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
                table: "Schedules",
                columns: new[] { "id", "date", "employeeFirst", "employeeLast", "employeeid", "isOnDuty", "room", "shiftId" },
                values: new object[] { 1, "2/2/2020", "EmployeeName", "EmployeeSurname", "1", false, "1", 1 });

            migrationBuilder.InsertData(
                table: "modelRooms",
                columns: new[] { "id", "Data", "EquipmentId" },
                values: new object[] { 1, "data", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointments_doctorUserId",
                table: "DoctorAppointments",
                column: "doctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointments_patientUserId",
                table: "DoctorAppointments",
                column: "patientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNotifications_DoctorUserId",
                table: "DoctorNotifications",
                column: "DoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsOrders_ManagersOrderid",
                table: "DoctorsOrders",
                column: "ManagersOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_DoctorsOrderid",
                table: "Equipment",
                column: "DoctorsOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_FinishedOrderid",
                table: "Equipment",
                column: "FinishedOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PharmacyOfferid",
                table: "Equipment",
                column: "PharmacyOfferid");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PrescriptionId",
                table: "Equipment",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_doctorId",
                table: "Equipment",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerNotification_ManagerUserId",
                table: "ManagerNotification",
                column: "ManagerUserId");

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
                name: "IX_Referrals_DoctorAppointmentid",
                table: "Referrals",
                column: "DoctorAppointmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_shiftId",
                table: "Schedules",
                column: "shiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorNotifications");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "ManagerNotification");

            migrationBuilder.DropTable(
                name: "ModelEquipment");

            migrationBuilder.DropTable(
                name: "ModelMedicine");

            migrationBuilder.DropTable(
                name: "modelRooms");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "PatientNotifications");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Renovation");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "SecretaryUsers");

            migrationBuilder.DropTable(
                name: "ManagerUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Referrals");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "DoctorsOrders");

            migrationBuilder.DropTable(
                name: "FinishedOrders");

            migrationBuilder.DropTable(
                name: "PharmacyOffers");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "DoctorAppointments");

            migrationBuilder.DropTable(
                name: "ManagersOrders");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
