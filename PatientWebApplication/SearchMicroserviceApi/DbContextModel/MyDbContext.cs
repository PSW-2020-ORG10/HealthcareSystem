using Microsoft.EntityFrameworkCore;
using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;

namespace SearchMicroserviceApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<OfferedMedicines> OfferedMedicines { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<ModelRoom> modelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelRoom>().HasData(
                new ModelRoom(1, "data", 1)
            );

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment(100, "Equipment name", 1, new List<ModelRoom>())
            );

            modelBuilder.Entity<Room>().HasData(
                new Room(1, "typeOfRoom", new List<ModelEquipment>(), new List<ModelMedicine>(), true)
            );

            Medicine medicine1 = new Medicine(1, "Pancef 300mg", 44, "For temperature", new List<ModelRoom>());
            Medicine medicine2 = new Medicine(2, "Defrinol 100mg", 2, "For headache", new List<ModelRoom>());
            Medicine medicine3 = new Medicine(3, "Brufen 200mg", 2, "For illness", new List<ModelRoom>());
            Medicine medicine4 = new Medicine(4, "Paracetamol 200mg", 4, "For temperature", new List<ModelRoom>());
            modelBuilder.Entity<Medicine>().HasData(
                medicine1,
                medicine2,
                medicine3,
                medicine4
            );

            modelBuilder.Entity<PrescribedMedicine>().HasData(
               new PrescribedMedicine(1, 1, 1, "Every 8 hours", 5),
               new PrescribedMedicine(2, 2, 2, "Whenever headache reapers", 5),
               new PrescribedMedicine(3, 3, 3, "Every 12 hours.", 5),
               new PrescribedMedicine(4, 4, 4, "Take one when body temperature exceedes 39 degrees", 5),
               new PrescribedMedicine(5, 1, 1, "Every 8 hours", 6),
               new PrescribedMedicine(6, 2, 2, "Whenever headache reapers", 6),
               new PrescribedMedicine(7, 3, 3, "Every 12 hours.", 6),
               new PrescribedMedicine(8, 4, 4, "Take one when body temperature exceedes 39 degrees", 6)
           );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription(1, 1, new List<PrescribedMedicine>(), false, "In case of allergy, stop taking medicine immediately.", 1, 1),
                new Prescription(2, 2, new List<PrescribedMedicine>(), true, "After finishing treatment, schedule control appointment.", 1, 2),
                new Prescription(3, 1, new List<PrescribedMedicine>(), true, "If illnness stops, stop taking medicine.", 2, 3),
                new Prescription(4, 1, new List<PrescribedMedicine>(), false, "In case of allergy, stop taking medicine immediately.", 1, 4),
                new Prescription(5, 2, new List<PrescribedMedicine>(), true, "After finishing treatment, schedule control appointment.", 1, 5),
                new Prescription(6, 1, new List<PrescribedMedicine>(), true, "If illnness stops, stop taking medicine.", 2, 6),
                new Prescription(7, 1, new List<PrescribedMedicine>(), false, "In case of allergy, stop taking medicine immediately.", 1, 7),
                new Prescription(8, 2, new List<PrescribedMedicine>(), true, "After finishing treatment, schedule control appointment.", 1, 8),
                new Prescription(9, 1, new List<PrescribedMedicine>(), true, "If illnness stops, stop taking medicine.", 2, 9),
                new Prescription(10, 1, new List<PrescribedMedicine>(), false, "In case of allergy, stop taking medicine immediately.", 1, 10),
                new Prescription(11, 2, new List<PrescribedMedicine>(), true, "After finishing treatment, schedule control appointment.", 1, 11),
                new Prescription(12, 1, new List<PrescribedMedicine>(), true, "If illnness stops, stop taking medicine.", 2, 12),
                new Prescription(13, 1, new List<PrescribedMedicine>(), false, "In case of allergy, stop taking medicine immediately.", 1, 13),
                new Prescription(14, 2, new List<PrescribedMedicine>(), true, "After finishing treatment, schedule control appointment.", 1, 14),
                new Prescription(15, 1, new List<PrescribedMedicine>(), true, "If illnness stops, stop taking medicine.", 2, 15)
            );

        }

    }
}
