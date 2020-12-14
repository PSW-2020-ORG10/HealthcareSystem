using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : Controller
    {
        private MessageService MessageService { get; set; }
        private RegistrationInPharmacyService RegistrationInPharmacyService { get; set; }
        private MedicineForOrderingRepository medicineRepository { get; set; }
        private DoctorOrderRepository orderRepository { get; set; }

        public ActionsAndBenefitsController(MyDbContext context)
        {
            MessageService = new MessageService(context);
            RegistrationInPharmacyService = new RegistrationInPharmacyService(context);
            medicineRepository = new MedicineForOrderingRepository(context);
            orderRepository = new DoctorOrderRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {/*
            MedicineForOrdering medicine1 = new MedicineForOrdering(2, "Paracetamol", 100, "Paracetamol is a medication used to treat pain and fever.", 2);
            MedicineForOrdering medicine2 = new MedicineForOrdering(3, "Ibuprofen", 80, "Ibuprofen is a medication used for treating pain, fever, and inflammation.", 2);
            MedicineForOrdering medicine3 = new MedicineForOrdering(4, "Clindamycin", 30, "Clindamycin is an antibiotic used for the treatment of a number of bacterial infections.", 2);
            MedicineForOrdering medicine4 = new MedicineForOrdering(5, "Palitrex", 100, ". Palitrex is indicated for the treatment of respiratory  infections.", 2);
            MedicineForOrdering medicine5 = new MedicineForOrdering(6, "Ibuprofen", 80, "Ibuprofen is a medication used for treating pain, fever, and inflammation.", 3);
            MedicineForOrdering medicine6 = new MedicineForOrdering(7, "Jomelop", 25, "Efficiently helps skin heal faster after sun-burns.", 3);
            MedicineForOrdering medicine7 = new MedicineForOrdering(8, "Antiseptics", 200, "Antiseptics substances that are applied to living tissue/skin to reduce the possibility of infection", 3);
            medicineRepository.Create(medicine1);
            medicineRepository.Create(medicine2);
            medicineRepository.Create(medicine3);
            medicineRepository.Create(medicine4);
            medicineRepository.Create(medicine5);
            medicineRepository.Create(medicine6);
            medicineRepository.Create(medicine7);
            

            DoctorsOrder order1 = new DoctorsOrder(2, false, new DateTime(2020, 3, 12), new DateTime(2020, 9, 9), true, true);
            DoctorsOrder order2 = new DoctorsOrder(3, true, new DateTime(2020, 8, 12), new DateTime(2020, 10, 9), true, true);
            orderRepository.Add(order1);
            orderRepository.Add(order2);
            */


            return Ok(MessageService.GetAll().Where(message => (RegistrationInPharmacyService.GetRegistrationByPharmacyName(GetName(message)) != null)));
        }
     
        private static string GetName(Message message)
        {
            return message.Text.Split(':')[0].Trim();
        }

      
    }
}

