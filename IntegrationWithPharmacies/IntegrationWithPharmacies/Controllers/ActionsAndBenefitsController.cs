using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;


namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : Controller
    {
        private MessageService MessageService { get;}

        public ActionsAndBenefitsController(MyDbContext context)
        {
            MessageService = new MessageService(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MessageService.GetAll().Where(message => (GetRegistrationByPharmacyName(GetName(message)) != null)));
        }
        public RegistrationInPharmacy GetRegistrationByPharmacyName(String name)
        {
            
            foreach (RegistrationInPharmacy registration in GetPharmacyRegistrations())
            {
                if (registration.Name.Equals(name)) return registration;
            }
            return null;
        }

        private static List<RegistrationInPharmacy> GetPharmacyRegistrations()
        {
            var client = new RestSharp.RestClient("http://localhost:54679");
            var registrations = client.Get<List<RegistrationInPharmacy>>(new RestRequest("/api/registration"));
            return registrations.Data;
        }


        private static String GetName(Message message)
        {
            return message.Text.Split(':')[0].Trim();
        }

      
    }
}

