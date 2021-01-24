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
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_DoctorAppointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorUserId = table.Column<int>(nullable: false),
                    Start = table.Column<TimeSpan>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    PatientUserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<string>(nullable: true),
                    End = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referrals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Diagnosis = table.Column<string>(nullable: true),
                    Procedure = table.Column<string>(nullable: true),
                    AppointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referrals_DoctorAppointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "DoctorAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: false),
                    DoctorsProfessionalism = table.Column<int>(nullable: false),
                    DoctorsPoliteness = table.Column<int>(nullable: false),
                    DoctorsTechnicality = table.Column<int>(nullable: false),
                    DoctorsSkill = table.Column<int>(nullable: false),
                    DoctorsKnowledge = table.Column<int>(nullable: false),
                    DoctorsWorkingPace = table.Column<int>(nullable: false),
                    MedicalStaffsProfessionalism = table.Column<int>(nullable: false),
                    MedicalStaffsPoliteness = table.Column<int>(nullable: false),
                    MedicalStaffsTechnicality = table.Column<int>(nullable: false),
                    MedicalStaffsSkill = table.Column<int>(nullable: false),
                    MedicalStaffsKnowledge = table.Column<int>(nullable: false),
                    MedicalStaffsWorkingPace = table.Column<int>(nullable: false),
                    HospitalEnvironment = table.Column<int>(nullable: false),
                    HospitalEquipment = table.Column<int>(nullable: false),
                    HospitalHygiene = table.Column<int>(nullable: false),
                    HospitalPrices = table.Column<int>(nullable: false),
                    HospitalWaitingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_DoctorAppointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "DoctorAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationReferrals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Diagnosis = table.Column<string>(nullable: true),
                    Procedure = table.Column<string>(nullable: true),
                    OperationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationReferrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationReferrals_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "Id", "CancelDateString", "Date", "DoctorUserId", "IsCanceled", "PatientUserId", "RoomId", "Start" },
                values: new object[,]
                {
                    { 7, null, "07/02/2031", 3, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 14, "09/01/2021", "23/12/2020", 2, true, 3, "1", new TimeSpan(0, 15, 45, 0, 0) },
                    { 1, null, "23/12/2020", 1, false, 2, "1", new TimeSpan(0, 14, 15, 0, 0) },
                    { 2, null, "23/12/2020", 2, false, 2, "1", new TimeSpan(0, 14, 30, 0, 0) },
                    { 3, null, "23/12/2020", 2, false, 1, "1", new TimeSpan(0, 15, 0, 0, 0) },
                    { 4, null, "23/12/2020", 2, false, 1, "1", new TimeSpan(0, 15, 45, 0, 0) },
                    { 5, null, "22/12/2020", 1, false, 1, "1", new TimeSpan(0, 12, 0, 0, 0) },
                    { 6, null, "22/12/2020", 3, false, 2, "1", new TimeSpan(0, 12, 15, 0, 0) },
                    { 15, "09/01/2021", "22/12/2020", 1, true, 3, "1", new TimeSpan(0, 12, 0, 0, 0) },
                    { 8, null, "07/12/2020", 2, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 9, null, "05/12/2030", 1, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 10, null, "11/11/2030", 2, false, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 11, null, "14/03/2016", 1, false, 2, "A2", new TimeSpan(0, 0, 0, 0, 0) },
                    { 12, null, "11/11/2010", 2, false, 2, "B3", new TimeSpan(0, 0, 0, 0, 0) },
                    { 13, "09/01/2021", "23/12/2020", 2, true, 3, "1", new TimeSpan(0, 15, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Date", "DoctorUserId", "End", "PatientUserId", "RoomId", "Start" },
                values: new object[,]
                {
                    { 1, "23/12/2020", 1, new TimeSpan(0, 15, 0, 0, 0), 2, "room1", new TimeSpan(0, 14, 0, 0, 0) },
                    { 2, "03/10/2020", 2, new TimeSpan(0, 15, 15, 0, 0), 1, "room1", new TimeSpan(0, 15, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Answer", "Name" },
                values: new object[] { 1, "Answer", "Name" });

            migrationBuilder.InsertData(
                table: "OperationReferrals",
                columns: new[] { "Id", "Diagnosis", "OperationId", "Procedure" },
                values: new object[,]
                {
                    { 1, "Bilateral upper eyelid dermatochalasis", 1, "This 65-year-old female demonstrates conditions described above of excess and redundant eyelid skin with puffiness and has requested surgical correction. The face was prepped and draped in the usual sterile manner. After waiting a period of approximately ten minutes for adequate vasoconstriction, the previously outlined excessive skin of the right upper eyelid was excised with blunt dissection. At the end of the operation the patientʼs vision and extraocular muscle movements were checked and found to be intact. The patient was released to return home in satisfactory condition." },
                    { 2, " Stage IV breast cancer with left breast mass.", 2, "The patient was brought into the operative room and placed on the operative table in the supine position. General endotracheal anesthesia was administered, and the patient was prepped and draped in the usual sterile fashion. A large lumpectomy was performed around the palpable mass extending down to the level of the muscle. The wound was then closed in two layers approximating the deep dermal layer with 3-0 Vicryl and the skin with 4-0 Monocryl. Steri-Strips and dressings were applied. The patient was extubated and transported to the recovery area in stable condition." }
                });

            migrationBuilder.InsertData(
                table: "Referrals",
                columns: new[] { "Id", "AppointmentId", "Diagnosis", "Procedure" },
                values: new object[,]
                {
                    { 1, 1, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment." },
                    { 2, 2, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation" },
                    { 3, 3, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment." },
                    { 4, 4, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation" },
                    { 5, 5, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment." },
                    { 6, 6, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation" },
                    { 7, 7, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment." },
                    { 8, 8, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation" },
                    { 9, 9, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment." },
                    { 10, 10, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation" },
                    { 11, 11, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment." },
                    { 12, 12, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "AppointmentId", "DoctorsKnowledge", "DoctorsPoliteness", "DoctorsProfessionalism", "DoctorsSkill", "DoctorsTechnicality", "DoctorsWorkingPace", "HospitalEnvironment", "HospitalEquipment", "HospitalHygiene", "HospitalPrices", "HospitalWaitingTime", "MedicalStaffsKnowledge", "MedicalStaffsPoliteness", "MedicalStaffsProfessionalism", "MedicalStaffsSkill", "MedicalStaffsTechnicality", "MedicalStaffsWorkingPace", "PatientId" },
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
                name: "IX_Surveys_AppointmentId",
                table: "Surveys",
                column: "AppointmentId");
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
