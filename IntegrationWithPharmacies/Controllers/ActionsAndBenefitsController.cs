using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : Controller
    {
        private MessageService MessageService { get; set; }
        private RegistrationInPharmacyService RegistrationInPharmacyService { get; set; }
   
        public ActionsAndBenefitsController(MyDbContext context)
        {
            MessageService = new MessageService(context);
            RegistrationInPharmacyService = new RegistrationInPharmacyService(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
           return Ok(getAllForVue());
        }

        private List<Message> getAllForVue()
        {
            List<Message> messageForVue = new List<Message>();
            foreach(Message message in MessageService.GetAll())
            {
                RegistrationInPharmacy registration = RegistrationInPharmacyService.getPharmacyName(GetName(message));
                if (registration != null) { messageForVue.Add(message); }
            }
            return messageForVue;
        }

        private static string GetName(Message message)
        {
            string[] parts = message.Text.Split(':');
            return parts[0].Trim();
        }
    }
}

