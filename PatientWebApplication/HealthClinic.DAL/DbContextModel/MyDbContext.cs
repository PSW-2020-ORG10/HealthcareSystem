using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Manager;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Model.Secretary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<PatientUser> Patients { get; set; }
        public DbSet<DoctorUser> Doctors { get; set; }
        public DbSet<ModelNotification> PatientNotifications { get; set; }
        public DbSet<DoctorNotification> DoctorNotifications { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<OperationReferral> OperationReferrals { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<OfferedMedicines> OfferedMedicines { get; set; }

        public DbSet<Renovation> Renovation { get; set; }

        public DbSet<Equipment> Equipment { get; set; }


        public DbSet<ModelRoom> modelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ManagerUser> ManagerUsers { get; set; }
        public DbSet<DoctorsOrder> DoctorsOrders { get; set; }
        public DbSet<FinishedOrder> FinishedOrders { get; set; }
        public DbSet<ManagersOrder> ManagersOrders { get; set; }
        public DbSet<PharmacyOffer> PharmacyOffers { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SecretaryUser> SecretaryUsers { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<RegistrationInPharmacy> Registrations { get; set; }
        public DbSet<MedicineForOrdering> MedicinesForOrdering { get; set; }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MedicineDescription> MedicineDescriptions { get; set; }
        public DbSet<EPrescription> EPrescriptions { get; set; }
        public DbSet<UrgentMedicineOrder> UrgentMedicineOrder { get; set; }
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
           ) ;

            modelBuilder.Entity<PatientUser>().HasData(
                new PatientUser(1, "Pera", "Peric","Male", "1234", "02/02/1990", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null),
                new PatientUser(2, "Marko", "Markovic", "Male", "123456789", "21/07/1989", "555333", "2112313", "Alergija", "Grad", false, "marko_markovic@gmail.com", "pass", false, "Grad2", "Roditelj", "images.jfif"),
                new PatientUser(3, "Stefan", "Lelic", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", "download.jfif"),
                new PatientUser(4, "Marko", "Lazarevic", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null)
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback(1, "First message", true, true, new DateTime(2020, 11, 2), 1),
                new Feedback(2, "Second message", false, false, new DateTime(2019, 6, 23), 1),
                new Feedback(3, "Third message", true, false, new DateTime(2020, 2, 12), 1),
                new Feedback(4, "Fourth message", true, false, new DateTime(2020, 9, 11), 1)
           );

            modelBuilder.Entity<Referral>().HasData(
                new Referral(1, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 1),
                new Referral(2, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 2),
                new Referral(3, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 3),
                new Referral(4, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 4),
                new Referral(5, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 5),
                new Referral(6, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 6),
                new Referral(7, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 7),
                new Referral(8, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 8),
                new Referral(9, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 9),
                new Referral(10, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 10),
                new Referral(11, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 11),
                new Referral(12, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 12)
           );

            modelBuilder.Entity<OperationReferral>().HasData(
                new OperationReferral(1, "Hemomycin", "15/09/2020", 1, "Operation", "Operation was successfull.", 1),
                new OperationReferral(2, "Amoxicillin", "18/10/2020", 3, "Operation", "Patient lost a lot of blood.", 2)
          );

            modelBuilder.Entity<Operation>().HasData(
                new Operation(1, 2, "23/12/2020", new TimeSpan(0, 14, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 1, "room1"),
                new Operation(2, 1, "03/10/2020", new TimeSpan(0, 15, 0, 0), new TimeSpan(0, 15, 15, 0, 0), 2, "room1")
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
                new Schedule(20, 1, "12/01/2021", true, 3, "Ordination 1")
           );

            modelBuilder.Entity<ModelRoom>().HasData(
                new ModelRoom(1, "data", 1)
            );

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment(1, "Equipment name", 1, new List <ModelRoom>())
            );


            modelBuilder.Entity<Renovation>().HasData(
                new Renovation(1, "1", "Start date", "End Date")
            );

            modelBuilder.Entity<Room>().HasData(
                new Room(1, "typeOfRoom", new List < ModelEquipment >(), new List < ModelMedicine >(), true)
            );

            modelBuilder.Entity<ManagerUser>().HasData(
                new ManagerUser(17, "Manager Name", "Manager Surname", "1234", "22/04/1993", "123","email", "pass", "Grad",
                200, new List <ManagerNotification>())
            );

            modelBuilder.Entity<DoctorsOrder>().HasData(
                new DoctorsOrder(1,false,new DateTime(), new DateTime(), true,true)
            );

            modelBuilder.Entity<FinishedOrder>().HasData(
                new FinishedOrder(1, new List <Medicine>())
            );

            modelBuilder.Entity<Message>().HasData(

                 new Message(1, "Message", "03/12/2020", new DateTime(), false, "Apoteka Jankovic", "02/02/2020")

              );

            modelBuilder.Entity<ManagersOrder>().HasData(
                new ManagersOrder(1, true, new List <DoctorsOrder>(), new DateTime(), true)
            );

            modelBuilder.Entity<PharmacyOffer>().HasData(
                new PharmacyOffer(1, "pharmacyName", new List < Medicine >(), 100.0)
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
                new DoctorAppointment(12, new TimeSpan(), "11/11/2010", 2, 2, new List<Referral>(), "B3")
            );

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber(1, 123, "Name")
            );

           
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine(51, "Pancef", 44, "For temperature", new List<ModelRoom>(), 1, false, 5),
                new Medicine(52, "Defrinol", 2, "For headache", new List<ModelRoom>(), 1, false, 7),
                new Medicine(53, "Brufen", 2, "For illness", new List<ModelRoom>(), 1, false, 8),
                new Medicine(54, "Paracetamol", 4, "For illness", new List<ModelRoom>(), 1, false, 6)
            );


            modelBuilder.Entity<Prescription>().HasData(
                new Prescription(5, 1, new List<Medicine>(), false, "Use every day", 1),
                new Prescription(6, 2, new List<Medicine>(), true, "When needed", 1),
                new Prescription(7, 1, new List<Medicine>(), true, "On every 12 hours", 2),
                new Prescription(8, 1, new List<Medicine>(), true, "After lunch", 1)
            );

            modelBuilder.Entity<Question>().HasData(
                new Question(1, "Name", "Answer")
            );

            modelBuilder.Entity<SecretaryUser>().HasData(
                new SecretaryUser(162, "Secretary Name", "Secretary Surname", "1234", "12/12/2012", "123", "email", "pass", "Grad",
                133, "Room")
            );

            modelBuilder.Entity<RegistrationInPharmacy>().HasData(
                new RegistrationInPharmacy(1, 1, "api1","Jankovic 1","Novi Sad")
            );

            modelBuilder.Entity<MedicineForOrdering>().HasData(
                new MedicineForOrdering(1,"Medicine name",1, "Medicine description", 1)
           );

            modelBuilder.Entity<Survey>().HasData(
                new Survey(1, 1, 3, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5),
                new Survey(2, 1, 4, 4, 5, 3, 1, 5, 5, 2, 2, 4, 2, 5, 3, 1, 3, 3, 3, 5)        
            );
            modelBuilder.Entity<MedicineDescription>().HasData(
               new MedicineDescription(1,"Analgin", "Analgin has anti - inflammatory, analgesic, antifebrile action.", 1)
               
           );
            modelBuilder.Entity<UrgentMedicineOrder>().HasData(
             new UrgentMedicineOrder(1,"Andol",135,"api 1","12/12/2020")

         );


        }

    }
}
