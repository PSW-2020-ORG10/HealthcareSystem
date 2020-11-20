using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Manager;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Patient;
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

           new DoctorUser(1, "DoctorName", "DoctorSurname", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1")


           );

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

            new Referral(1, "Medicine", "Take medicine until", 3, "classify", "comment")

           );

            modelBuilder.Entity<Operation>().HasData(

            new Operation(1, 1, "2/2/2020", new TimeSpan(), new TimeSpan(), 1, "room1", 1)

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

            modelBuilder.Entity<OfferedMedicines>().HasData(

            new OfferedMedicines(13, "OfferedMedicine", 2, "description", new List <ModelRoom>(), 1, false, 10.0, 1)

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

            new DoctorAppointment(1, new TimeSpan(), "22/04/2020", 2, 1, new List < Referral >(), "1")

            );

            modelBuilder.Entity<PhoneNumber>().HasData(

            new PhoneNumber(1, 123, "Name")

            );

           
            modelBuilder.Entity<Medicine>().HasData(

             new Medicine(22, "Medicine Name", 2, "Medicine Description", new List<ModelRoom>(), 1, false, 1)


            );


            modelBuilder.Entity<Prescription>().HasData(

            new Prescription(1, 1, new List<Medicine>(), true, "Comment"),
            new Prescription(2, 2, null, true, "Some text")

            );

            modelBuilder.Entity<Question>().HasData(

            new Question(1, "Name", "Answer")

            );

            modelBuilder.Entity<SecretaryUser>().HasData(

            new SecretaryUser(1, "Secretary Name", "Secretary Surname", "1234", "12/12/2012", "123", "email", "pass", "Grad",
            133, "Room")

            );

            
            
        }

    }
}
