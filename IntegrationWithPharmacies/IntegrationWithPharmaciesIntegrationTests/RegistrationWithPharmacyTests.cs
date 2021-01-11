using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PharmacyRegistrationApi.DbContextModel;
using PharmacyRegistrationApi.Dtos;
using PharmacyRegistrationApi.Model;
using PharmacyRegistrationApi.Service;
using PharmacyRegistrationApi;
using Shouldly;
using Xunit;

namespace IntegrationWithPharmaciesIntegrationTests
{
    public class RegistrationWithPharmacyTests
    {
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
            RegistrationInPharmacyService registrationInPharmacyService = new RegistrationInPharmacyService(_context);

            RegistrationInPharmacy registrationInPharmacy = registrationInPharmacyService.Create(new RegistrationInPharmacyDto(5, "apisa12345", "Jankovic 2", "Novi Sad"));
            registrationInPharmacy.ShouldBeNull();
        }
      
    }
}
