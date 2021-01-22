using MedicineInformationApi.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicineInformationApi.DbContextModel
{
    public class MyDbContext : DbContext
    {
        public DbSet<MedicineInformation> MedicineInformations { get; set; }
        public DbSet<MedicineDescription> MedicineDescriptions { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineDescription>().HasData(
                new MedicineDescription("Paracetamol", "Paracetamol is a nonsteroidal anti-inflammatory drug (NSAID) used to treat mild-to-moderate pain, and helps to relieve symptoms of arthritis.", 1),
                new MedicineDescription("Brufen", "Brufen is used to reduce fever and relieve mild to moderate pain.", 2),
                new MedicineDescription("Defrinol", "Defrinol is used to treat certain types of bacterial infections.", 3),
                new MedicineDescription("Pancef", "Pancef is indicated for: Headache, Colds & Influenza, Backache, Period Pain, Pain of Osteoarthritis, Muscle Pain, Toothache, Rheumatic Pain", 4),
                new MedicineDescription("Analgin", "Analgin is indicated for: Headache, Colds & Influenza, Backache, Period Pain, Pain of Osteoarthritis, Muscle Pain, Toothache, Rheumatic Pain", 5)

            );

            modelBuilder.Entity<MedicineInformation>().HasData(
                new MedicineInformation(1, 150),
                new MedicineInformation(2, 100),
                new MedicineInformation(3, 44),
                new MedicineInformation(4, 33),
                new MedicineInformation(5, 30)

            );
        }
    }
}
