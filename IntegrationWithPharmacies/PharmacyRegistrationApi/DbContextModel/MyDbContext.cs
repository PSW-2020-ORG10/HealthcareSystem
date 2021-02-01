using PharmacyRegistrationApi.Model;
using Microsoft.EntityFrameworkCore;


namespace PharmacyRegistrationApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {

        public DbSet<RegistrationInPharmacy> Registrations { get; set; }
        public DbSet<PharmacyConnectionInfo> RegistrationsInfo { get; set; }

        public DbSet<PharmacyNameInfo> PharmacyNameInfos { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PharmacyConnectionInfo>().HasData(
                new PharmacyConnectionInfo("65ftvyubuef74f8H", "jankovic1@gmail.com", "http://localhost:8086",1),
                new PharmacyConnectionInfo("65ftvyubuef74f8G", "benu1@gmail.com", "http://localhost:8082", 2)
            );
            modelBuilder.Entity<PharmacyNameInfo>().HasData(
               new PharmacyNameInfo("Jankovic 1", 1),
                new PharmacyNameInfo("Benu 1", 2)
           );
            modelBuilder.Entity<RegistrationInPharmacy>().HasData(
                new RegistrationInPharmacy(1, 1, "Novi Sad"),
                new RegistrationInPharmacy(2, 2, "Novi Sad")

            );

        }
    }
}
