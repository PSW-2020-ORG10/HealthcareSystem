using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using IntegrationWithPharmacies.FileProtocol;
using IntegrationWithPharmacies.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : Controller
    {
        private UrgentOrderService UrgentOrderService { get; }
        private HttpService HttpService { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; }
        public UrgentOrderController(MyDbContext context)
        {
            UrgentOrderService = new UrgentOrderService(context);
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
        }

        [HttpPost]
        public IActionResult Post(UrgentMedicineOrder order)
        {
            if (UrgentOrderService.SendOrderGrpc(order)) return Ok();
            return BadRequest();
        }

        [HttpPost("http")]
        public IActionResult PostHttp(UrgentMedicineOrder order)
        {
            Console.WriteLine("pogodiooooooooooooooooooooooooooooooooooooo");
            if (UrgentOrderService.SendOrderHttp(order)) return Ok();
            return BadRequest();
        }

        [HttpGet("http/medicineAvailability/{medicine}")]
        public IActionResult GetMedicineAvailability(String medicine)
        {
            String trazeno = HttpService.FormMedicineAvailabilityRequest(medicine);
            List<MedicineName> pharmaciesWithMedicine = MedicineAvailabilityTable.FormMedicineAvailability(trazeno);
            if (pharmaciesWithMedicine == null) return BadRequest();
            return Ok(pharmaciesWithMedicine[0]);
           
            
        }

    }
}
