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
                new MedicineDescription("Andol", "Against pain",1)
            );

            modelBuilder.Entity<MedicineInformation>().HasData(
                new MedicineInformation(1, 150)
            );
        }
    }
}
