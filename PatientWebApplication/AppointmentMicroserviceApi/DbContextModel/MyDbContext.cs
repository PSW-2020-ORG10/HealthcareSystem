using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<OperationReferral> OperationReferrals { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referral>().HasData(
                new Referral(1, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment.", 1),
                new Referral(2, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation", 2),
                new Referral(3, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment.", 3),
                new Referral(4, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation", 4),
                new Referral(5, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment.", 5),
                new Referral(6, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation", 6),
                new Referral(7, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment.", 7),
                new Referral(8, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation", 8),
                new Referral(9, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment.", 9),
                new Referral(10, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation", 10),
                new Referral(11, "Pneumonia", "Patient had temperature taken. Temperature was 39.6 degrees. Listened to patients breathing. Breathing was slightly constricted. Established that patient has lighter case of pneumonia. Sent home for home treatment.", 11),
                new Referral(12, "Concussion", "Patient had visible gash on back of his head. Patient complains of blurred vision. Established that patient has concussion. Left for a night of hospital observation", 12)
           );

            modelBuilder.Entity<OperationReferral>().HasData(
                new OperationReferral(1, "Bilateral upper eyelid dermatochalasis", "This 65-year-old female demonstrates conditions described above of excess and redundant eyelid skin with puffiness and has requested surgical correction. The face was prepped and draped in the usual sterile manner. After waiting a period of approximately ten minutes for adequate vasoconstriction, the previously outlined excessive skin of the right upper eyelid was excised with blunt dissection. At the end of the operation the patientʼs vision and extraocular muscle movements were checked and found to be intact. The patient was released to return home in satisfactory condition.", 1),
                new OperationReferral(2, " Stage IV breast cancer with left breast mass.", "The patient was brought into the operative room and placed on the operative table in the supine position. General endotracheal anesthesia was administered, and the patient was prepped and draped in the usual sterile fashion. A large lumpectomy was performed around the palpable mass extending down to the level of the muscle. The wound was then closed in two layers approximating the deep dermal layer with 3-0 Vicryl and the skin with 4-0 Monocryl. Steri-Strips and dressings were applied. The patient was extubated and transported to the recovery area in stable condition.", 2)
          );

            modelBuilder.Entity<Operation>().HasData(
                new Operation(1, 2, "23/12/2020", new TimeSpan(0, 14, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 1, "room1"),
                new Operation(2, 1, "03/10/2020", new TimeSpan(0, 15, 0, 0), new TimeSpan(0, 15, 15, 0, 0), 2, "room1")
            );

            modelBuilder.Entity<DoctorAppointment>().HasData(
                new DoctorAppointment(1, new TimeSpan(0, 14, 15, 0, 0), "23/12/2020", 2, 1, new List<Referral>(), "1"),
                new DoctorAppointment(2, new TimeSpan(0, 14, 30, 0, 0), "23/12/2020", 2, 2, new List<Referral>(), "1"),
                new DoctorAppointment(3, new TimeSpan(0, 15, 0, 0, 0), "23/12/2020", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(4, new TimeSpan(0, 15, 45, 0, 0), "23/12/2020", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(5, new TimeSpan(0, 12, 0, 0, 0), "22/12/2020", 1, 1, new List<Referral>(), "1"),
                new DoctorAppointment(6, new TimeSpan(0, 12, 15, 0, 0), "22/12/2020", 2, 3, new List<Referral>(), "1"),
                new DoctorAppointment(7, new TimeSpan(), "07/02/2031", 1, 3, new List<Referral>(), "1"),
                new DoctorAppointment(8, new TimeSpan(), "07/12/2020", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(9, new TimeSpan(), "05/12/2030", 1, 1, new List<Referral>(), "1"),
                new DoctorAppointment(10, new TimeSpan(), "11/11/2030", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(11, new TimeSpan(), "14/03/2016", 2, 1, new List<Referral>(), "A2"),
                new DoctorAppointment(12, new TimeSpan(), "11/11/2010", 2, 2, new List<Referral>(), "B3"),
                new DoctorAppointment(13, new TimeSpan(0, 15, 0, 0, 0), "23/12/2020", 3, 2, new List<Referral>(), "1", true, "09/01/2021"),
                new DoctorAppointment(14, new TimeSpan(0, 15, 45, 0, 0), "23/12/2020", 3, 2, new List<Referral>(), "1", true, "09/01/2021"),
                new DoctorAppointment(15, new TimeSpan(0, 12, 0, 0, 0), "22/12/2020", 3, 1, new List<Referral>(), "1", true, "09/01/2021")
            );

            modelBuilder.Entity<Question>().HasData(
                new Question(1, "Name", "Answer")
            );

            modelBuilder.Entity<Survey>().HasData(
                new Survey(1, 1, 3, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5),
                new Survey(2, 1, 4, 4, 5, 3, 1, 5, 5, 2, 2, 4, 2, 5, 3, 1, 3, 3, 3, 5)
            );


        }

    }
}
