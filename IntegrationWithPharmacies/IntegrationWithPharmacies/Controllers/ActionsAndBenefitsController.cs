using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
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
            return new RestClient("http://localhost:54679").Get<List<RegistrationInPharmacy>>(new RestRequest("/api/registration")).Data;
        }


        private static String GetName(Message message)
        {
            return message.Text.Split(':')[0].Trim();
        }

      
    }
}

