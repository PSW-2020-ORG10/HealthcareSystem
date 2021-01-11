using System;
using System.Linq;
using EPrescriptionApi.Model;
using EPrescriptionApi.Utility;
using Microsoft.AspNetCore.Mvc;

namespace EPrescriptionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : ControllerBase
    {
        private HttpRequests HttpRequests { get; }
        public ActionsAndBenefitsController()
        {
            HttpRequests = new HttpRequests();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(HttpRequests.GetAllMessages().Where(message => (GetRegistrationByPharmacyName(GetName(message)) != null)));
        }
        public RegistrationInPharmacy GetRegistrationByPharmacyName(String name)
        {
            return HttpRequests.GetPharmacyRegistrations().SingleOrDefault(pharmacy => pharmacy.Name.Equals(name));
        }
    
        private static String GetName(Message message)
        {
            return message.Text.Split(':')[0].Trim();
        }
    }
}