
using IntegrationWithPharmacies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TenderApi.Model;
using TenderApi.DbContextModel;
using Xunit;

namespace IntegrationWithPharmaciesIntegrationTests
{
    public  class MedicineOrderTests
    {
        private readonly HttpClient _client;
        private  MyDbContext _context;


        public MedicineOrderTests()
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
        public async Task Creates_Tender()
        {
            List<MedicineTenderOffer> medicineQuantityList = new List<MedicineTenderOffer>();
            MedicineTenderOffer medicineQuantity1 = new MedicineTenderOffer("Brufen", 10);
            MedicineTenderOffer medicineQuantity2 = new MedicineTenderOffer("Pancef", 50);
            medicineQuantityList.Add(medicineQuantity1);
            medicineQuantityList.Add(medicineQuantity2);
            TenderOrder tender = new TenderOrder(medicineQuantityList,"12/01/2020");
            var stringContent = new StringContent(JsonConvert.SerializeObject(tender), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:50921/api/tender", stringContent);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task Gets_Active_Tenders()
        {
            _context.Tender.Add(new Tender(10, new DateTime(), false));
            _context.MedicineForTendering.Add(new MedicineForTendering(10, "Brufen", 5, 10));
            _context.MedicineForTendering.Add(new MedicineForTendering(11, "Andol", 10, 10));
            _context.SaveChanges();
            var response = await _client.GetAsync("http://localhost:50921/api/tender/active");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var tenders = await response.Content.ReadAsAsync<List<TenderOrder>>();
            tenders.ShouldNotBeEmpty();
        }
     
        [Fact]
        public async Task Gets_Tender_By_Id()
        {
            _context.Tender.Add(new Tender(20, new DateTime(), false));
            _context.SaveChanges();
            var response = await _client.GetAsync("http://localhost:50921/api/tender/" + "20");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var tender = await response.Content.ReadAsAsync<TenderOrder>();
            tender.ShouldNotBeNull();
        }
        [Fact]
        public async Task Gets_No_Tender_By_Id()
        {
            var response = await _client.GetAsync("http://localhost:50921/api/tender/" + "15");
            var tender = await response.Content.ReadAsAsync<TenderOrder>();
            tender.ShouldBeNull();
        }

        [Fact]
        public async Task Creates_Pharmacy_Tender_Offer()
        {
            List<MedicineTenderOffer> medicineQuantityList = new List<MedicineTenderOffer>();
            MedicineTenderOffer medicineQuantity1 = new MedicineTenderOffer("Brufen", 10,8,5,0);
            MedicineTenderOffer medicineQuantity2 = new MedicineTenderOffer("Pancef", 50,40,3,0);
            medicineQuantityList.Add(medicineQuantity1);
            medicineQuantityList.Add(medicineQuantity2);
            TenderOrder tender = new TenderOrder(medicineQuantityList, "12/01/2020",10,0,"apiKye");
            var stringContent = new StringContent(JsonConvert.SerializeObject(tender), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:50921/api/tender", stringContent);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Gets_All_Pharmacy_Offers_For_Tender()
        {
            var response = await _client.GetAsync("http://localhost:50921/api/tender/allPharmacyOffers/" + "10");
            var offers = await response.Content.ReadAsAsync<List<TenderOrder>>();
            offers.ShouldNotBeNull();
        }

    }
}
