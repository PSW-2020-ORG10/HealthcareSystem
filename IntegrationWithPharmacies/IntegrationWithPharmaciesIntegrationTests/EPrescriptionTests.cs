/*using EPrescriptionApi.Model;
using EPrescriptionApi;
using MedicineInformationApi.DbContextModel;
using MedicineInformationApi.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationWithPharmaciesIntegrationTests
{
    public class EPrescriptionTests
    {
        private readonly HttpClient _client;
        private readonly MyDbContext _context;

        public EPrescriptionTests()
        {
            var builder = new WebHostBuilder()
               .UseEnvironment("Testing")
               .UseStartup<Startup>();

            var server = new TestServer(builder);
            _context = server.Host.Services.GetService(typeof(MyDbContext)) as MyDbContext;
            _client = server.CreateClient();
        }
        [Fact]
        public async Task Get_Medicines_From_Isa()
        {
            var response = await _client.GetAsync("http://localhost:57942/api/sharingPrescription/medicinesIsa");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var medicines =  await response.Content.ReadAsAsync<List<MedicineName>>();
            medicines.ShouldNotBeEmpty();
        }
       

        [Fact]
        public async Task Get_Medicines_Availability()
        {
            var response = await _client.GetAsync("http://localhost:57942/api/sharingPrescription/http/medicineAvailability/Brufen_2");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var medicines = await response.Content.ReadAsAsync<List<MedicineName>>();
            medicines.ShouldNotBeEmpty();
        }
        [Fact]
        public async Task Get_No_Medicines_Availability()
        {
            var response = await _client.GetAsync("http://localhost:57942/api/sharingPrescription/http/medicineAvailability/Brufen_100");
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
        
        
    }
}
*/