using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentMicroserviceApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorAppointments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorUserId = table.Column<int>(nullable: false),
                    Start = table.Column<TimeSpan>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    PatientUserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<string>(nullable: true),
                    IsCanceled = table.Column<bool>(nullable: false),
                    CancelDateString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAppointments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorUserId = table.Column<int>(nullable: false),
                    Start = table.Column<TimeSpan>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    PatientUserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<string>(nullable: true),
                    end = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.id);
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
                    AppointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Referrals_DoctorAppointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "DoctorAppointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(nullable: false),
                    appointmentId = table.Column<int>(nullable: false),
                    doctorsProfessionalism = table.Column<int>(nullable: false),
                    doctorsPoliteness = table.Column<int>(nullable: false),
                    doctorsTechnicality = table.Column<int>(nullable: false),
                    doctorsSkill = table.Column<int>(nullable: false),
                    doctorsKnowledge = table.Column<int>(nullable: false),
                    doctorsWorkingPace = table.Column<int>(nullable: false),
                    medicalStaffsProfessionalism = table.Column<int>(nullable: false),
                    medicalStaffsPoliteness = table.Column<int>(nullable: false),
                    medicalStaffsTechnicality = table.Column<int>(nullable: false),
                    medicalStaffsSkill = table.Column<int>(nullable: false),
                    medicalStaffsKnowledge = table.Column<int>(nullable: false),
                    medicalStaffsWorkingPace = table.Column<int>(nullable: false),
                    hospitalEnvironment = table.Column<int>(nullable: false),
                    hospitalEquipment = table.Column<int>(nullable: false),
                    hospitalHygiene = table.Column<int>(nullable: false),
                    hospitalPrices = table.Column<int>(nullable: false),
                    hospitalWaitingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.id);
                    table.ForeignKey(
                        name: "FK_Surveys_DoctorAppointments_appointmentId",
                        column: x => x.appointmentId,
                        principalTable: "DoctorAppointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationReferrals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    medicine = table.Column<string>(nullable: true),
                    takeMedicineUntil = table.Column<string>(nullable: true),
                    quantityPerDay = table.Column<int>(nullable: false),
                    classify = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    OperationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationReferrals", x => x.id);
                    table.ForeignKey(
                        name: "FK_OperationReferrals_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "CancelDateString", "Date", "DoctorUserId", "IsCanceled", "PatientUserId", "RoomId", "Start" },
                values: new object[,]
                {
                    { 1, null, "23/12/2020", 1, false, 2, "1", new TimeSpan(0, 14, 15, 0, 0) },
                    { 2, null, "23/12/2020", 2, false, 2, "1", new TimeSpan(0, 14, 30, 0, 0) },
                    { 3, null, "23/12/2020", 2, false, 1, "1", new TimeSpan(0, 15, 0, 0, 0) },
                    { 4, null, "23/12/2020", 2, false, 1, "1", new TimeSpan(0, 15, 45, 0, 0) },
                    { 5, null, "22/12/2020", 1, false, 1, "1", new TimeSpan(0, 12, 0, 0, 0) },
                    { 6, null, "22/12/2020", 3, false, 2, "1", new TimeSpan(0, 12, 15, 0, 0) },
                    { 7, null, "07/02/2031", 3, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 8, null, "07/12/2020", 2, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 9, null, "05/12/2030", 1, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 10, null, "11/11/2030", 2, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 11, null, "14/03/2016", 1, false, 2, "A2", new TimeSpan(0, 0, 0, 0, 0) },
                    { 12, null, "11/11/2010", 2, false, 2, "B3", new TimeSpan(0, 0, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "id", "Date", "DoctorUserId", "PatientUserId", "RoomId", "Start", "end" },
                values: new object[,]
                {
                    { 1, "23/12/2020", 1, 2, "room1", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 2, "03/10/2020", 2, 1, "room1", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 15, 15, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "id", "answer", "name" },
                values: new object[] { 1, "Answer", "Name" });

            migrationBuilder.InsertData(
                table: "OperationReferrals",
                columns: new[] { "id", "OperationId", "classify", "comment", "medicine", "quantityPerDay", "takeMedicineUntil" },
                values: new object[,]
                {
                    { 1, 1, "Operation", "Operation was successfull.", "Hemomycin", 1, "15/09/2020" },
                    { 2, 2, "Operation", "Patient lost a lot of blood.", "Amoxicillin", 3, "18/10/2020" }
                });

            migrationBuilder.InsertData(
                table: "Referrals",
                columns: new[] { "id", "AppointmentId", "classify", "comment", "medicine", "quantityPerDay", "takeMedicineUntil" },
                values: new object[,]
                {
                    { 1, 1, "classify", "Patient had slight heart arrhythmia.", "Aspirin", 3, "25/02/2020" },
                    { 2, 2, "Appointment", "Patient had cold.", "Brufen", 1, "11/05/2020" },
                    { 3, 3, "classify", "Patient had slight heart arrhythmia.", "Aspirin", 3, "25/02/2020" },
                    { 4, 4, "Appointment", "Patient had cold.", "Brufen", 1, "11/05/2020" },
                    { 5, 5, "classify", "Patient had slight heart arrhythmia.", "Aspirin", 3, "25/02/2020" },
                    { 6, 6, "Appointment", "Patient had cold.", "Brufen", 1, "11/05/2020" },
                    { 7, 7, "classify", "Patient had slight heart arrhythmia.", "Aspirin", 3, "25/02/2020" },
                    { 8, 8, "Appointment", "Patient had cold.", "Brufen", 1, "11/05/2020" },
                    { 9, 9, "classify", "Patient had slight heart arrhythmia.", "Aspirin", 3, "25/02/2020" },
                    { 10, 10, "Appointment", "Patient had cold.", "Brufen", 1, "11/05/2020" },
                    { 11, 11, "classify", "Patient had slight heart arrhythmia.", "Aspirin", 3, "25/02/2020" },
                    { 12, 12, "Appointment", "Patient had cold.", "Brufen", 1, "11/05/2020" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "id", "appointmentId", "doctorsKnowledge", "doctorsPoliteness", "doctorsProfessionalism", "doctorsSkill", "doctorsTechnicality", "doctorsWorkingPace", "hospitalEnvironment", "hospitalEquipment", "hospitalHygiene", "hospitalPrices", "hospitalWaitingTime", "medicalStaffsKnowledge", "medicalStaffsPoliteness", "medicalStaffsProfessionalism", "medicalStaffsSkill", "medicalStaffsTechnicality", "medicalStaffsWorkingPace", "patientId" },
                values: new object[,]
                {
                    { 1, 3, 4, 5, 4, 5, 4, 5, 3, 3, 2, 2, 5, 5, 5, 4, 5, 5, 4, 1 },
                    { 2, 4, 5, 5, 4, 1, 3, 5, 1, 3, 3, 3, 5, 5, 2, 2, 2, 4, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationReferrals_OperationId",
                table: "OperationReferrals",
                column: "OperationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_AppointmentId",
                table: "Referrals",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_appointmentId",
                table: "Surveys",
                column: "appointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationReferrals");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Referrals");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "DoctorAppointments");
        }
    }
}
