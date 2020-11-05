using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using HCI_wireframe;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Model.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<PatientUser> Patients { get; set; }
        public DbSet<DoctorUser> Doctors { get; set; }
        public DbSet<ModelNotification> PatientNotifications { get; set; }
        public DbSet<DoctorNotification> DoctorNotifications { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Referral> Referrals { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientUser patient = new PatientUser(1, "Pera", "Peric", "1234", "2/2/2020", "123", "1234", "Alergija", "Grad", false, "email", "pass", false, new List<ModelNotification>());
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
             200.0, false, "Specialty", new List < DoctorNotification >() , "Ordination 1")


           ); 

            modelBuilder.Entity<PatientUser>().HasData(

           new PatientUser(1, "Pera", "Peric", "1234", "2/2/2020", "123", "1234", "Alergija", "Grad", false, "email", "pass", false, new List<ModelNotification>())


           );

            modelBuilder.Entity<Feedback>().HasData(

            new Feedback(1, "First message", true, true, 1),
            new Feedback(2, "Second message", false, false, 1),
            new Feedback(3, "Third message", true, false, 1)


           );

            modelBuilder.Entity<Referral>().HasData(

            new Referral(1, "Medicine", "Take medicine until", 3, "classify", "comment")

           );

            modelBuilder.Entity<Operation>().HasData(

            new Operation(1, 1, "2/2/2020", new TimeSpan(), new TimeSpan(), 1, "room1", 1)

           );
        }

    }
}
