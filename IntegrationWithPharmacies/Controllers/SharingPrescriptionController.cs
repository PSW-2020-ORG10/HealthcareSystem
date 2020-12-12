using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SharingPrescriptionController : Controller
    {
        private MedicineService MedicineService { get; set; }
        public SharingPrescriptionController(MyDbContext context)
        {
            MedicineService = new MedicineService(context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MedicineService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(RequestedMedicine requested)
        {
            return Ok();
        }

    }
}
