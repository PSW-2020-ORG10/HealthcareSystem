using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using EPrescriptionApi.Model;
using EPrescriptionApi.Service;
using EPrescriptionApi.Utility;
using Microsoft.AspNetCore.Mvc;


namespace EPrescriptionApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SharingPrescriptionController : Controller
    {
        private PrescriptionFileService PrescriptionFileService { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; }
        private HttpRequests HttpRequests { get; }

        public SharingPrescriptionController()
        {
            PrescriptionFileService = new PrescriptionFileService();
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
            HttpRequests = new HttpRequests();
        }

        [HttpGet("medicinesIsa")]
        public IActionResult GetMedicinesFromIsa()
        {
            if (Startup.SystemEnvironment.Equals("Development"))return Ok(HttpRequests.GetAllMedicinesFromDatabase());
            else return Ok(HttpRequests.FormMedicineFromIsaRequest().Data);
        }

        [HttpPost]
        public IActionResult Post(EPrescription prescription)
        {
            if (Startup.SystemEnvironment.Equals("Development"))
            {
                if (PrescriptionFileService.SendPrescriptionSftp(prescription)) return Ok();
                return BadRequest();
            }
            if (PrescriptionFileService.SendPrescriptionHttp(prescription))return Ok();
            return BadRequest();
        }

        [HttpGet("description/{medicine}")]
        public IActionResult GetMedicineDescription(String medicine)
        {
            if (Startup.SystemEnvironment.Equals("Production")) return GetMedicineDescriptionHttp(medicine);
            return GetMedicineDescriptionGrpc(medicine);
        }

        private IActionResult GetMedicineDescriptionHttp(string medicine)
        {
            String medicineDescription = HttpRequests.GetMedicineDescriptionFromApi(medicine);
            if (medicineDescription.IsNullOrEmpty()) return GetMedicineDescriptionFromIsaHttpAsync(medicine);
            return Ok(medicineDescription);
        }

        public IActionResult GetMedicineDescriptionFromIsaHttpAsync(string medicine)
        {
            String description = HttpRequests.FormMedicineDescriptionRequest(medicine);
            _ = HttpRequests.CreateNewMedicineWithQuantityAsync(medicine, description);
            if (description.Length != 0) return Ok(description);
            return BadRequest();
        }
       
        public IActionResult GetMedicineDescriptionGrpc(string medicine)
        {
            String medicineDescription = HttpRequests.GetMedicineDescriptionFromApi(medicine);
            if (medicineDescription.IsNullOrEmpty())return GetMedicineDescriptionFromIsaGrpc(medicine);
            return Ok(medicineDescription);
        }

        private IActionResult GetMedicineDescriptionFromIsaGrpc(string medicine)
        {
            string response = new ClientScheduledService().SendMessage(medicine).Result;
            _ = HttpRequests.CreateNewMedicineWithQuantityAsync(medicine, response);
            return Ok(response);
        }

        [HttpGet("http/medicineAvailability/{medicine}")]
        public IActionResult GetMedicineAvailability(String medicine)
        {
            List<MedicineName> pharmaciesWithMedicine = MedicineAvailabilityTable.FormMedicineAvailability(HttpRequests.FormMedicineAvailabilityRequest(medicine));
            if (pharmaciesWithMedicine == null) return BadRequest();
            return Ok(pharmaciesWithMedicine);
        }
    }
}
