using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


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
           return Ok(MessageService.GetAll().Where(message => (RegistrationInPharmacyService.GetRegistrationByPharmacyName(GetName(message)) != null)));
        }
     
        private static string GetName(Message message)
        {
            return message.Text.Split(':')[0].Trim();
        }

      
    }
}

