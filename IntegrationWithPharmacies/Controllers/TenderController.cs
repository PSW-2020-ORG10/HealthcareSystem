using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private TenderingService TenderingService { get; }
        private TenderService TenderService { get; }
        private TenderAdapter TenderAdapter { get; }
        private MedicineForTenderingAdapter MedicineForTenderingAdapter { get; }
        private MedicineForTenderingService MedicineForTenderingService { get; }
        public TenderController(MyDbContext context)
        {
            TenderingService = new TenderingService(context);
            MedicineForTenderingAdapter = new MedicineForTenderingAdapter();
            TenderAdapter = new TenderAdapter();
            MedicineForTenderingService = new MedicineForTenderingService(context);
            TenderService = new TenderService(context);
        }

        [HttpPost]
        public IActionResult Post(TenderOrder tender)
        {
            TenderOrder tenderInstance = new TenderOrder(tender.MedicinesWithQuantity, tender.Date);
            CreateTender(tender);
            CreateMedicineForTendering(tender);
            if (TenderingService.PublishTender(tenderInstance)) return Ok();
            return BadRequest();
        }
        private void CreateMedicineForTendering(TenderOrder tender)
        { 
            foreach(MedicineQuantity medicineQuantity in tender.MedicinesWithQuantity)
            {
                Console.WriteLine(medicineQuantity.MedicineName + " " + medicineQuantity.Quantity);
                MedicineForTenderingService.Create(MedicineForTenderingAdapter.MedicineForebderingToMedicineForTenderingDto(new MedicineForTendering(medicineQuantity.MedicineName,medicineQuantity.Quantity,getTenderId())));
            }
           
        }
        private void CreateTender(TenderOrder tender)
        {
                TenderService.Create(TenderAdapter.TenderToTenderDto(new Tender(new DateTime(2020,5,5),false)));
            

        }

        private int getTenderId()
        {
            int max = 0;
            foreach(Tender tender in TenderService.GetAll())
            {
                if (max < tender.id) max = tender.id;
            }
            return max;
        }
    }
}