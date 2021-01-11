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

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelRoom>().HasData(
                new ModelRoom(1, "data", 1)
            );

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment(1, "Equipment name", 1, new List<ModelRoom>())
            );

            modelBuilder.Entity<Room>().HasData(
                new Room(1, "typeOfRoom", new List<ModelEquipment>(), new List<ModelMedicine>(), true)
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

        }

    }
}
