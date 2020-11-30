using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : Controller
    {
            private MessageService MessageService { get; set; }
            public ActionsAndBenefitsController(MyDbContext context)
            {
                 MessageService = new MessageService(context);
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(MessageService.GetAll());
            }



        }
    }

