using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthClinic.CL.Services;
using Class_diagram.Model.Patient;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using IntegrationWithPharmacies.FileProtocol;
using System.IO;
using Microsoft.Extensions.Logging.Abstractions;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Model.Orders;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationInPharmacyService registrationInPharmacyService { get; set; }
        //private MedicineForOrderingRepository medicineRepository { get; set; }
      //  private DoctorOrderRepository orderRepository { get; set; }

        public RegistrationController(MyDbContext context)
        {
            registrationInPharmacyService = new RegistrationInPharmacyService(context);
            //medicineRepository = new MedicineForOrderingRepository(context);
           // orderRepository = new DoctorOrderRepository(context);
        }

        [HttpGet]   // GET /api/registration
        public IActionResult Get()
        {
           /* MedicineForOrdering medicine1= new MedicineForOrdering(2,"Paracetamol", 100, "Paracetamol is a medication used to treat pain and fever.", 2);

            MedicineForOrdering medicine2 = new MedicineForOrdering(3,"Ibuprofen", 80, "Ibuprofen is a medication used for treating pain, fever, and inflammation.", 2);
            MedicineForOrdering medicine3 = new MedicineForOrdering(4,"Clindamycin", 30, "Clindamycin is an antibiotic used for the treatment of a number of bacterial infections.", 2);
            MedicineForOrdering medicine4 = new MedicineForOrdering(5,"Palitrex", 100, ". Palitrex is indicated for the treatment of respiratory  infections.", 2);
            MedicineForOrdering medicine5 = new MedicineForOrdering(6,"Ibuprofen", 80, "Ibuprofen is a medication used for treating pain, fever, and inflammation.", 3);
            MedicineForOrdering medicine6 = new MedicineForOrdering(7,"Jomelop", 25, "Efficiently helps skin heal faster after sun-burns.", 3);
            MedicineForOrdering medicine7 = new MedicineForOrdering(8,"Antiseptics", 200, "Antiseptics substances that are applied to living tissue/skin to reduce the possibility of infection", 3);

            medicineRepository.Create(medicine1);
            medicineRepository.Create(medicine2);
            medicineRepository.Create(medicine3);
            medicineRepository.Create(medicine4);
            medicineRepository.Create(medicine5);
            medicineRepository.Create(medicine6);
            medicineRepository.Create(medicine7);
            

            DoctorsOrder order1 = new DoctorsOrder(2,false, new DateTime(2020, 3, 12), new DateTime(2020, 9, 9), true, true);
            DoctorsOrder order2 = new DoctorsOrder(3,true, new DateTime(2020, 8, 12), new DateTime(2020, 10, 9), true, true);
            orderRepository.Add(order1);
            orderRepository.Add(order2);*/

          

            return Ok(registrationInPharmacyService.GetAll());
        }

        [HttpPost]      // POST /api/registration Request body: {"pharmacyId": "Some number", "apiKey": "Some api key"}
        public IActionResult Post(RegistrationInPharmacyDto dto)
        {
           
            if (registrationInPharmacyService.Create(dto) == null) return BadRequest();

            return Ok();
        }


    }
}