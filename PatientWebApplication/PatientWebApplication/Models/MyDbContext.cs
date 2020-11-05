using Class_diagram.Model.Patient;
using HCI_wireframe;
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
        public DbSet<ModelNotification> Notifications { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientUser patient = new PatientUser(1, "Pera", "Peric", "1234", "2/2/2020", "123", "1234", "Alergija", "Grad", false, "email", "pass", false, new List<ModelNotification>());
            List<ModelNotification> lista = new List<ModelNotification>();
            lista.Add(new ModelNotification(3, "3. string", 1));
            modelBuilder.Entity<ModelNotification>().HasData(

                lista


           );

            modelBuilder.Entity<PatientUser>().HasData(

           new PatientUser(1, "Pera", "Peric", "1234", "2/2/2020", "123", "1234", "Alergija", "Grad", false, "email", "pass", false, new List<ModelNotification>())


           );

            modelBuilder.Entity<Feedback>().HasData(

            new Feedback(1, "First message", true, true, 1),
            new Feedback(2, "Second message", false, false, 1),
            new Feedback(3, "Third message", true, false, 1)


           );
        }

    }
}
