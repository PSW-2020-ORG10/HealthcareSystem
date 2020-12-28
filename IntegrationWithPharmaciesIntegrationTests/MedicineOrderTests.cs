using IntegrationWithPharmacies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationWithPharmaciesIntegrationTests
{
    public  class MedicineOrderTests
    {/*
        private readonly HttpClient _client;
     
        public MedicineOrderTests()
        {
            var builder = new WebHostBuilder()
               .UseEnvironment("Testing")
               .UseStartup<Startup>();

            var server = new TestServer(builder);
            _client = server.CreateClient();
        }

        [Fact]
        public async Task Creates_Urgent_Order()
        {
            var response = await _client.GetAsync("http://localhost:57942/api/urgentOrder/http/Brufen_3");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Creates_No_Urgent_Order()
        {
            var response = await _client.GetAsync("http://localhost:57942/api/urgentOrder/http/Brufen_100");
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
        */
    }
}
