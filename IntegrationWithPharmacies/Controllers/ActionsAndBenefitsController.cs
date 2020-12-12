using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : Controller
    {
        private MessageService MessageService { get; set; }
        private RegistrationInPharmacyService RegistrationInPharmacyService { get; set; }
        private MedicineForOrderingRepository medicineRepository { get; set; }
        private DoctorOrderRepository orderRepository { get; set; }

        public ActionsAndBenefitsController(MyDbContext context)
        {
            MessageService = new MessageService(context);
            RegistrationInPharmacyService = new RegistrationInPharmacyService(context);
            medicineRepository = new MedicineForOrderingRepository(context);
            orderRepository = new DoctorOrderRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            SendGetRequestWithRestSharp();
           return Ok(MessageService.GetAll().Where(message => (RegistrationInPharmacyService.GetRegistrationByPharmacyName(GetName(message)) != null)));
        }
     
        private static string GetName(Message message)
        {
            return message.Text.Split(':')[0].Trim();
        }

        private static void SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:8082");
            var request = new RestRequest("/medicineRequested");
            var response = client.Get<List<Medicine2>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<Medicine2> result = response.Data;
            result.ForEach(medicine => Console.WriteLine(medicine.ToString()));
        }


        private static void SendGetRequestWithRestSharp2()
        {
            var client = new RestSharp.RestClient("http://localhost:8082");
            var request = new RestRequest("medicine/description2/Panadol");
            var response = client.Get<MedicineDescription>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            MedicineDescription result = response.Data;
            Console.WriteLine(result.ToString());
        }



        private async Task<System.IO.Stream> Upload(string paramString, Stream paramFileStream, byte[] paramFileBytes)
        {
            HttpContent stringContent = new StringContent(paramString);
            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
                var response = await client.PostAsync("http://localhost:8082/medicine/files/Panadol", formData);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return await response.Content.ReadAsStreamAsync();
            }
        }
    }
}

