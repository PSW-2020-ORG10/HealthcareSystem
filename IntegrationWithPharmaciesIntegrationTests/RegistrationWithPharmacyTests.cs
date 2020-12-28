using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Shouldly;
using Xunit;

namespace IntegrationWithPharmaciesIntegrationTests
{
    public class RegistrationWithPharmacyTests
    {/*
        private readonly MyDbContext _context;

        public RegistrationWithPharmacyTests()
        {
            var builder = new WebHostBuilder()
               .UseEnvironment("Testing")
               .UseStartup<Startup>();

            var server = new TestServer(builder);
            _context = server.Host.Services.GetService(typeof(MyDbContext)) as MyDbContext;
        }
        [Fact]
        public void Creates_registration()
        {
            RegistrationInPharmacyService registrationInPharmacyService = new RegistrationInPharmacyService(_context);

            RegistrationInPharmacy registrationInPharmacy = registrationInPharmacyService.Create(new RegistrationInPharmacyDto(5, "apisa12345", "Jankovic 2", "Novi Sad"));
            registrationInPharmacy.ShouldNotBeNull();
        }
        [Fact]
        public void Creates_no_registration()
        {
            _context.Registrations.Add(new RegistrationInPharmacy(1, 1, "api1", "Apotreka Jankovic", "Beograd"));
            _context.SaveChanges();
            RegistrationInPharmacyService registrationInPharmacyService = new RegistrationInPharmacyService(_context);

            RegistrationInPharmacy registrationInPharmacy = registrationInPharmacyService.Create(new RegistrationInPharmacyDto(5, "api1", "Jankovic 2", "Novi Sad"));
            registrationInPharmacy.ShouldBeNull();
        }
      */
    }
}
