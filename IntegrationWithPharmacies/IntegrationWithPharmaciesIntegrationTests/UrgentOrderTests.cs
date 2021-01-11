using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MedicineInformationApi;
using MedicineInformationApi.Model;

using MedicineInformationApi.DbContextModel;
using Xunit;

namespace IntegrationWithPharmaciesIntegrationTests
{
    public class UrgentOrderTests
    {/*
        private readonly HttpClient _client;
        private MyDbContext _context;


        public UrgentOrderTests()
        {
            var builder = new WebHostBuilder()
               .UseEnvironment("Testing")
               .UseStartup<Startup>();

            var server = new TestServer(builder);
            _client = server.CreateClient();
            _context = server.Host.Services.GetService(typeof(MyDbContext)) as MyDbContext;

        }

        [Fact]
        public async Task Creates_Urgent_Order()
        {
            var response = await _client.GetAsync("http://localhost:59328/api/urgentOrder/http/Brufen_3");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Creates_No_Urgent_Order()
        {
            var response = await _client.GetAsync("http://localhost:59328/api/urgentOrder/http/Brufen_100");
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Get_Medicine_Description()
        {
            _context.MedicineWithQuantity.Add(new MedicineWithQuantity(6, "Brufen", 6, "Description"));
            _context.SaveChanges();
            var response = await _client.GetAsync("http://localhost:57942/api/sharingPrescription/http/description/Brufen");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }*/
    }
}
