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

        public DbSet<Survey> Surveys { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientUser patient = new PatientUser(1, "Pera", "Peric","Male", "1234", "2/2/2020", "123","213", "Alergija", "Grad", false, "email", "pass", false,"Grad2", "Roditelj",null);
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

           new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1"),
           new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1"),
            new DoctorUser(3, "Milica", "Tadic", "12346", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1")


           ) ;

            modelBuilder.Entity<PatientUser>().HasData(

            new PatientUser(1, "Pera2", "Peric","Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null),
            new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null)

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

            new Operation(1, 2, "20/02/2020", new TimeSpan(), new TimeSpan(), 1, "room1"),
            new Operation(2, 2, "03/10/2020", new TimeSpan(), new TimeSpan(), 2, "room1")

            );



            modelBuilder.Entity<Shift>().HasData(

            new Shift(1, "Start time", "End time")

            );

            modelBuilder.Entity<Schedule>().HasData(

            new Schedule(1, "1", "2/2/2020", false, "EmployeeName", "EmployeeSurname", 1, "1")

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

            new DoctorsOrder(1, false, new List <Medicine>(), new DateTime(), true)

            );

            modelBuilder.Entity<FinishedOrder>().HasData(

            new FinishedOrder(1, new List <Medicine>())

            );

            modelBuilder.Entity<ManagersOrder>().HasData(

            new ManagersOrder(1, true, new List <DoctorsOrder>(), new DateTime(), true)

            );

            modelBuilder.Entity<PharmacyOffer>().HasData(

            new PharmacyOffer(1, "pharmacyName", new List < Medicine >(), 100.0)

            );

            modelBuilder.Entity<DoctorAppointment>().HasData(

             new DoctorAppointment(1, new TimeSpan(), "22/04/2020", 2, 1, new List<Referral>(), "1"),
            new DoctorAppointment(2, new TimeSpan(), "07/01/2020", 2, 2, new List<Referral>(), "1"),
            new DoctorAppointment(3, new TimeSpan(), "05/07/2019", 1, 3, new List<Referral>(), "1"),
            new DoctorAppointment(4, new TimeSpan(), "04/02/2019", 1, 1, new List<Referral>(), "1"),
            new DoctorAppointment(5, new TimeSpan(), "11/01/2016", 1, 2, new List<Referral>(), "1"),
            new DoctorAppointment(6, new TimeSpan(), "09/01/2014", 1, 3, new List<Referral>(), "1"),
            new DoctorAppointment(7, new TimeSpan(), "07/02/2011", 1, 3, new List<Referral>(), "1"),
            new DoctorAppointment(8, new TimeSpan(), "01/03/2020", 1, 2, new List<Referral>(), "1"),
            new DoctorAppointment(9, new TimeSpan(), "14/03/2016", 1, 1, new List<Referral>(), "1"),
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

            new SecretaryUser(1, "Secretary Name", "Secretary Surname", "1234", "12/12/2012", "123", "email", "pass", "Grad",
            133, "Room")

            );

            modelBuilder.Entity<RegistrationInPharmacy>().HasData(

            new RegistrationInPharmacy(1, 1, "Api key")

            );

            modelBuilder.Entity<Survey>().HasData(

            new Survey(1,1, 1, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5)

            );


        }

    }
}
