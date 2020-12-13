using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpReferalController : ControllerBase
    {
        private static void SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:8082");
            var response = client.Get<String>(new RestRequest("/medicine/description/Panadol"));
            Console.WriteLine("Status: " + response.StatusCode.ToString()+"\n"+response.Data);
        }
    }
}