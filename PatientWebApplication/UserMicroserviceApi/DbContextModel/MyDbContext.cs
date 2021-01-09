using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<PatientUser> Patients { get; set; }
        public DbSet<DoctorUser> Doctors { get; set; }
        public DbSet<ModelNotification> PatientNotifications { get; set; }
        public DbSet<DoctorNotification> DoctorNotifications { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ManagerUser> ManagerUsers { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<SecretaryUser> SecretaryUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<ModelNotification> patientNotifications = new List<ModelNotification>();
            patientNotifications.Add(new ModelNotification(3, "3. string", 1));
            modelBuilder.Entity<ModelNotification>().HasData(

                patientNotifications


           );

            List<DoctorNotification> doctorNotifications = new List<DoctorNotification>();
            doctorNotifications.Add(new DoctorNotification(3, "3. string", 1));
            modelBuilder.Entity<DoctorNotification>().HasData(
                doctorNotifications
           );

            modelBuilder.Entity<DoctorUser>().HasData(
                new DoctorUser(1, "Konstantin", "Davidovic", "1234", "02/02/1975", "123", "email", "pass", "Grad",
                200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 1"),
                new DoctorUser(2, "Novak", "Maric", "12345", "02/02/1982", "123", "email", "pass", "Grad",
                200.0, false, "Pulmonology", new List<DoctorNotification>(), "Ordination 2"),
                new DoctorUser(3, "Milica", "Tadic", "12346", "02/02/1988", "123", "email", "pass", "Grad",
                200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 3"),
                new DoctorUser(4, "Jovan", "Jovanovic", "12346", "02/02/1988", "123", "email", "pass", "Grad",
                200.0, false, "Pulmonology", new List<DoctorNotification>(), "Ordination 4")
           );

            PatientUser patient1 = new PatientUser(1, "Pera", "Peric", "Male", "1234", "02/02/1990", "123", "212313", "Alergija", "Grad", false, "patient1@gmail.com", "12345", false, "Grad2", "Roditelj", "download.jfif");
            PatientUser patient2 = new PatientUser(2, "Marko", "Markovic", "Male", "123456789", "21/07/1989", "555333", "2112313", "Alergija", "Grad", false, "marko_markovic@gmail.com", "12345", false, "Grad2", "Roditelj", "images.jfif");
            PatientUser patient3 = new PatientUser(3, "Stefan", "Lelic", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "patient2@gmail.com", "12345", false, "Grad2", "Roditelj", "download.jfif");
            PatientUser patient4 = new PatientUser(4, "Marko", "Lazarevic", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "patient2@gmail.com", "12345", false, "Grad2", "Roditelj", "download.jfif");
            patient1.isVerified = true;
            patient2.isVerified = true;
            patient3.isVerified = true;

            modelBuilder.Entity<PatientUser>().HasData(
                patient1,
                patient2,
                patient3,
                patient4
            );

            modelBuilder.Entity<Shift>().HasData(
                new Shift(1, "14:00", "16:00"),
                new Shift(2, "12:00", "12:30"),
                new Shift(3, "08:00", "19:00"),
                new Shift(4, "08:00", "23:00")
            );

            modelBuilder.Entity<Schedule>().HasData(
                new Schedule(1, 1, "08/12/2020", true, 3, "Ordination 1"),
                new Schedule(2, 1, "09/12/2020", true, 3, "Ordination 1"),
                new Schedule(3, 1, "10/12/2020", true, 3, "Ordination 1"),
                new Schedule(4, 1, "11/12/2020", true, 3, "Ordination 1"),
                new Schedule(5, 1, "12/12/2020", true, 3, "Ordination 1"),
                new Schedule(6, 1, "13/12/2020", true, 3, "Ordination 1"),
                new Schedule(7, 1, "14/12/2020", true, 3, "Ordination 1"),
                new Schedule(8, 1, "15/12/2020", true, 3, "Ordination 1"),
                new Schedule(9, 1, "16/12/2020", true, 3, "Ordination 1"),
                new Schedule(10, 1, "17/12/2020", true, 3, "Ordination 1"),
                new Schedule(11, 1, "18/12/2020", true, 3, "Ordination 1"),
                new Schedule(12, 1, "19/12/2020", true, 4, "Ordination 1"),
                new Schedule(13, 1, "20/12/2020", true, 3, "Ordination 1"),
                new Schedule(14, 1, "21/12/2020", true, 3, "Ordination 1"),
                new Schedule(15, 1, "23/12/2020", true, 3, "Ordination 1"),
                new Schedule(16, 2, "23/12/2020", true, 1, "1"),
                new Schedule(17, 1, "22/12/2020", true, 2, "1"),
                new Schedule(18, 3, "22/12/2020", true, 1, "1"),
                new Schedule(19, 4, "23/12/2020", true, 1, "1"),
                new Schedule(20, 1, "12/01/2021", true, 4, "Ordination 1"),
                new Schedule(21, 1, "25/12/2020", true, 4, "1"),
                new Schedule(22, 1, "29/12/2020", true, 3, "1")
           );

            modelBuilder.Entity<ManagerUser>().HasData(
                new ManagerUser(17, "Manager Name", "Manager Surname", "1234", "22/04/1993", "123", "email", "pass", "Grad",
                200, new List<ManagerNotification>())
            );

            modelBuilder.Entity<Message>().HasData(

                 new Message(1, "Introducing our new commercial for your old family friend: Defrinol Forte!", "03/12/2020", new DateTime(), false, "Apoteka Jankovic", "02/02/2020"),
                 new Message(2, "The bag saves lives, if there is an Andol in it!", "03/12/2020", new DateTime(), false, "Apoteka Jankovic", "02/02/2020"),
                 new Message(3, "Protects the heart, protects the brain, Aspirin!", "03/12/2020", new DateTime(), false, "Apoteka Jankovic", "02/02/2020")

              );

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber(1, 123, "Name")
            );

            modelBuilder.Entity<SecretaryUser>().HasData(
                new SecretaryUser(162, "Secretary Name", "Secretary Surname", "1234", "12/12/2012", "123", "email", "pass", "Grad",
                133, "Room")
            );

            modelBuilder.Entity<Administrator>().HasData(
                new Administrator(5, "Pera", "Peric", "1234", "12/12/1985", "123", "admin1@gmail.com", "password", "Grad",133),
                new Administrator(6, "Ana", "Stanic", "1234", "12/12/1985", "123", "admin2@gmail.com", "password", "Grad", 133)
            );
        }

    }
}
