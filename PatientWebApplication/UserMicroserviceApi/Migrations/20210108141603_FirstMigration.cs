using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeUser",
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
                    Discriminator = table.Column<string>(nullable: false),
                    isSpecialist = table.Column<bool>(nullable: true),
                    ordination = table.Column<string>(nullable: true),
                    speciality = table.Column<string>(nullable: true),
                    room = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    DateStamp = table.Column<string>(nullable: true),
                    IsRemoved = table.Column<bool>(nullable: false),
                    PharmacyName = table.Column<string>(nullable: true),
                    DateAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
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
                    exLastname = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    file = table.Column<string>(nullable: true),
                    isBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
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
                        name: "FK_DoctorNotifications_EmployeeUser_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "EmployeeUser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_ManagerNotification_EmployeeUser_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "EmployeeUser",
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
                name: "Schedules",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    isOnDuty = table.Column<bool>(nullable: false),
                    shiftId = table.Column<int>(nullable: false),
                    room = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_Schedules_EmployeeUser_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeUser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Shifts_shiftId",
                        column: x => x.shiftId,
                        principalTable: "Shifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "id", "Discriminator", "city", "dateOfBirth", "email", "firstName", "password", "phoneNumber", "salary", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[,]
                {
                    { 5, "Administrator", "Grad", "12/12/1985", "admin1@gmail.com", "Pera", "password", "123", 133.0, "Peric", "1234" },
                    { 6, "Administrator", "Grad", "12/12/1985", "admin2@gmail.com", "Ana", "password", "123", 133.0, "Stanic", "1234" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "id", "Discriminator", "city", "dateOfBirth", "email", "firstName", "password", "phoneNumber", "salary", "secondName", "uniqueCitizensidentityNumber", "isSpecialist", "ordination", "speciality" },
                values: new object[,]
                {
                    { 1, "DoctorUser", "Grad", "02/02/1975", "email", "Konstantin", "pass", "123", 200.0, "Davidovic", "1234", false, "Ordination 1", "Cardiology" },
                    { 2, "DoctorUser", "Grad", "02/02/1982", "email", "Novak", "pass", "123", 200.0, "Maric", "12345", false, "Ordination 2", "Pulmonology" },
                    { 3, "DoctorUser", "Grad", "02/02/1988", "email", "Milica", "pass", "123", 200.0, "Tadic", "12346", false, "Ordination 3", "Cardiology" },
                    { 4, "DoctorUser", "Grad", "02/02/1988", "email", "Jovan", "pass", "123", 200.0, "Jovanovic", "12346", false, "Ordination 4", "Pulmonology" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "id", "Discriminator", "city", "dateOfBirth", "email", "firstName", "password", "phoneNumber", "salary", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 17, "ManagerUser", "Grad", "22/04/1993", "email", "Manager Name", "pass", "123", 200.0, "Manager Surname", "1234" });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "id", "Discriminator", "city", "dateOfBirth", "email", "firstName", "password", "phoneNumber", "salary", "secondName", "uniqueCitizensidentityNumber", "room" },
                values: new object[] { 162, "SecretaryUser", "Grad", "12/12/2012", "email", "Secretary Name", "pass", "123", 133.0, "Secretary Surname", "1234", "Room" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "id", "DateAction", "DateStamp", "IsRemoved", "PharmacyName", "Text", "TimeStamp" },
                values: new object[,]
                {
                    { 3, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "Protects the heart, protects the brain, Aspirin!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "Introducing our new commercial for your old family friend: Defrinol Forte!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "The bag saves lives, if there is an Andol in it!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "allergie", "bornIn", "city", "dateOfBirth", "email", "exLastname", "file", "firstName", "gender", "guest", "isBlocked", "isMarried", "isRegisteredBySecretary", "isVerified", "medicalIdNumber", "parentName", "password", "phoneNumber", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[,]
                {
                    { 1, "Alergija", "Grad2", "Grad", "02/02/1990", "patient1@gmail.com", "", null, "Pera", "Male", false, false, false, false, false, "212313", "Roditelj", "12345", "123", "Peric", "1234" },
                    { 2, "Alergija", "Grad2", "Grad", "21/07/1989", "marko_markovic@gmail.com", "", "images.jfif", "Marko", "Male", false, false, false, false, false, "2112313", "Roditelj", "12345", "555333", "Markovic", "123456789" },
                    { 3, "Alergija", "Grad2", "Grad", "2/2/2020", "patient2@gmail.com", "", "download.jfif", "Stefan", "Male", false, false, false, false, false, "212313", "Roditelj", "12345", "123", "Lelic", "1234" },
                    { 4, "Alergija", "Grad2", "Grad", "2/2/2020", "patient2@gmail.com", "", null, "Marko", "Female", false, false, false, false, false, "2112313", "Roditelj", "12345", "123", "Lazarevic", "1234" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "id", "name", "number" },
                values: new object[] { 1, "Name", 123 });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "id", "endTime", "startTime" },
                values: new object[,]
                {
                    { 3, "19:00", "08:00" },
                    { 1, "16:00", "14:00" },
                    { 2, "12:30", "12:00" },
                    { 4, "23:00", "08:00" }
                });

            migrationBuilder.InsertData(
                table: "DoctorNotifications",
                columns: new[] { "id", "Data", "DoctorUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.InsertData(
                table: "PatientNotifications",
                columns: new[] { "id", "Data", "PatientUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "id", "EmployeeId", "date", "isOnDuty", "room", "shiftId" },
                values: new object[,]
                {
                    { 12, 1, "19/12/2020", true, "Ordination 1", 4 },
                    { 22, 1, "29/12/2020", true, "1", 3 },
                    { 15, 1, "23/12/2020", true, "Ordination 1", 3 },
                    { 14, 1, "21/12/2020", true, "Ordination 1", 3 },
                    { 13, 1, "20/12/2020", true, "Ordination 1", 3 },
                    { 11, 1, "18/12/2020", true, "Ordination 1", 3 },
                    { 10, 1, "17/12/2020", true, "Ordination 1", 3 },
                    { 9, 1, "16/12/2020", true, "Ordination 1", 3 },
                    { 8, 1, "15/12/2020", true, "Ordination 1", 3 },
                    { 7, 1, "14/12/2020", true, "Ordination 1", 3 },
                    { 6, 1, "13/12/2020", true, "Ordination 1", 3 },
                    { 5, 1, "12/12/2020", true, "Ordination 1", 3 },
                    { 4, 1, "11/12/2020", true, "Ordination 1", 3 },
                    { 3, 1, "10/12/2020", true, "Ordination 1", 3 },
                    { 2, 1, "09/12/2020", true, "Ordination 1", 3 },
                    { 1, 1, "08/12/2020", true, "Ordination 1", 3 },
                    { 17, 1, "22/12/2020", true, "1", 2 },
                    { 19, 4, "23/12/2020", true, "1", 1 },
                    { 18, 3, "22/12/2020", true, "1", 1 },
                    { 16, 2, "23/12/2020", true, "1", 1 },
                    { 20, 1, "12/01/2021", true, "Ordination 1", 4 },
                    { 21, 1, "25/12/2020", true, "1", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNotifications_DoctorUserId",
                table: "DoctorNotifications",
                column: "DoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerNotification_ManagerUserId",
                table: "ManagerNotification",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNotifications_PatientUserId",
                table: "PatientNotifications",
                column: "PatientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EmployeeId",
                table: "Schedules",
                column: "EmployeeId");

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
                name: "ManagerNotification");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PatientNotifications");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "EmployeeUser");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
