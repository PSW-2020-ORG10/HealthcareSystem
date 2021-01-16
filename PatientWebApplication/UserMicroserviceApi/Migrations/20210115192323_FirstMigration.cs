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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    UniqueCitizensidentityNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IsSpecialist = table.Column<bool>(nullable: true),
                    Ordination = table.Column<string>(nullable: true),
                    Speciality = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    UniqueCitizensidentityNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MedicalIdNumber = table.Column<string>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    Allergie = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Guest = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsRegisteredBySecretary = table.Column<bool>(nullable: false),
                    IsMarried = table.Column<bool>(nullable: false),
                    BornIn = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    ExLastname = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    File = table.Column<string>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    DoctorUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorNotifications_EmployeeUser_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "EmployeeUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagerNotification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    ManagerUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagerNotification_EmployeeUser_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "EmployeeUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    PatientUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientNotifications_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    IsOnDuty = table.Column<bool>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    Room = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_EmployeeUser_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "Id", "City", "DateOfBirth", "Discriminator", "Email", "FirstName", "Password", "PhoneNumber", "Salary", "SecondName", "UniqueCitizensidentityNumber" },
                values: new object[,]
                {
                    { 5, "Grad", "12/12/1985", "Administrator", "admin1@gmail.com", "Pera", "password", "123", 133.0, "Peric", "1234" },
                    { 6, "Grad", "12/12/1985", "Administrator", "admin2@gmail.com", "Ana", "password", "123", 133.0, "Stanic", "1234" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "Id", "City", "DateOfBirth", "Discriminator", "Email", "FirstName", "Password", "PhoneNumber", "Salary", "SecondName", "UniqueCitizensidentityNumber", "IsSpecialist", "Ordination", "Speciality" },
                values: new object[,]
                {
                    { 1, "Grad", "02/02/1975", "DoctorUser", "email", "Konstantin", "pass", "123", 200.0, "Davidovic", "1234", false, "Ordination 1", "Cardiology" },
                    { 2, "Grad", "02/02/1982", "DoctorUser", "email", "Novak", "pass", "123", 200.0, "Maric", "12345", false, "Ordination 2", "Pulmonology" },
                    { 3, "Grad", "02/02/1988", "DoctorUser", "email", "Milica", "pass", "123", 200.0, "Tadic", "12346", false, "Ordination 3", "Cardiology" },
                    { 4, "Grad", "02/02/1988", "DoctorUser", "email", "Jovan", "pass", "123", 200.0, "Jovanovic", "12346", false, "Ordination 4", "Pulmonology" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "Id", "City", "DateOfBirth", "Discriminator", "Email", "FirstName", "Password", "PhoneNumber", "Salary", "SecondName", "UniqueCitizensidentityNumber" },
                values: new object[] { 17, "Grad", "22/04/1993", "ManagerUser", "email", "Manager Name", "pass", "123", 200.0, "Manager Surname", "1234" });

            migrationBuilder.InsertData(
                table: "EmployeeUser",
                columns: new[] { "Id", "City", "DateOfBirth", "Discriminator", "Email", "FirstName", "Password", "PhoneNumber", "Salary", "SecondName", "UniqueCitizensidentityNumber", "Room" },
                values: new object[] { 162, "Grad", "12/12/2012", "SecretaryUser", "email", "Secretary Name", "pass", "123", 133.0, "Secretary Surname", "1234", "Room" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "DateAction", "DateStamp", "IsRemoved", "PharmacyName", "Text", "TimeStamp" },
                values: new object[,]
                {
                    { 3, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "Protects the heart, protects the brain, Aspirin!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "Introducing our new commercial for your old family friend: Defrinol Forte!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "The bag saves lives, if there is an Andol in it!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Allergie", "BornIn", "City", "DateOfBirth", "Email", "ExLastname", "File", "FirstName", "Gender", "Guest", "IsBlocked", "IsMarried", "IsRegisteredBySecretary", "IsVerified", "MedicalIdNumber", "ParentName", "Password", "PhoneNumber", "SecondName", "UniqueCitizensidentityNumber" },
                values: new object[,]
                {
                    { 1, "Alergija", "Grad2", "Grad", "02/02/1990", "patient1@gmail.com", "", "download.jfif", "Pera", "Male", false, false, false, false, true, "212313", "Roditelj", "12345", "123", "Peric", "1234" },
                    { 2, "Alergija", "Grad2", "Grad", "21/07/1989", "marko_markovic@gmail.com", "", "man.jfif", "Marko", "Male", false, false, false, false, true, "2112313", "Roditelj", "12345", "555333", "Markovic", "123456789" },
                    { 3, "Alergija", "Grad2", "Grad", "2/2/2020", "patient2@gmail.com", "", "download.jfif", "Stefan", "Male", false, false, false, false, true, "212313", "Roditelj", "12345", "123", "Lelic", "1234" },
                    { 4, "Alergija", "Grad2", "Grad", "2/2/2020", "patient2@gmail.com", "", "man.jfif", "Marko", "Female", false, false, false, false, false, "2112313", "Roditelj", "12345", "123", "Lazarevic", "1234" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Name", "Number" },
                values: new object[] { 1, "Name", 123 });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 3, "19:00", "08:00" },
                    { 1, "16:00", "14:00" },
                    { 2, "12:30", "12:00" },
                    { 4, "23:00", "08:00" }
                });

            migrationBuilder.InsertData(
                table: "DoctorNotifications",
                columns: new[] { "Id", "Data", "DoctorUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.InsertData(
                table: "PatientNotifications",
                columns: new[] { "Id", "Data", "PatientUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Date", "EmployeeId", "IsOnDuty", "Room", "ShiftId" },
                values: new object[,]
                {
                    { 12, "19/12/2020", 1, true, "Ordination 1", 4 },
                    { 23, "31/01/2020", 1, true, "1", 3 },
                    { 22, "29/12/2020", 1, true, "1", 3 },
                    { 15, "23/12/2020", 1, true, "Ordination 1", 3 },
                    { 14, "21/12/2020", 1, true, "Ordination 1", 3 },
                    { 13, "20/12/2020", 1, true, "Ordination 1", 3 },
                    { 11, "18/12/2020", 1, true, "Ordination 1", 3 },
                    { 10, "17/12/2020", 1, true, "Ordination 1", 3 },
                    { 9, "16/12/2020", 1, true, "Ordination 1", 3 },
                    { 8, "15/12/2020", 1, true, "Ordination 1", 3 },
                    { 7, "14/12/2020", 1, true, "Ordination 1", 3 },
                    { 6, "13/12/2020", 1, true, "Ordination 1", 3 },
                    { 5, "12/12/2020", 1, true, "Ordination 1", 3 },
                    { 4, "11/12/2020", 1, true, "Ordination 1", 3 },
                    { 3, "10/12/2020", 1, true, "Ordination 1", 3 },
                    { 2, "09/12/2020", 1, true, "Ordination 1", 3 },
                    { 1, "08/12/2020", 1, true, "Ordination 1", 3 },
                    { 17, "22/12/2020", 1, true, "1", 2 },
                    { 19, "23/12/2020", 4, true, "1", 1 },
                    { 18, "22/12/2020", 3, true, "1", 1 },
                    { 16, "23/12/2020", 2, true, "1", 1 },
                    { 20, "12/01/2021", 1, true, "Ordination 1", 4 },
                    { 21, "25/12/2020", 1, true, "1", 4 }
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
                name: "IX_Schedules_ShiftId",
                table: "Schedules",
                column: "ShiftId");
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
