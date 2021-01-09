using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;


namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SharingPrescriptionController : Controller
    {
        private String Environment { get; }
        private PatientService PatientService { get; set; }
        private PrescriptionFileService PrescriptionFileService { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; } 
        private HttpService HttpService { get; }

        public SharingPrescriptionController(MyDbContext context)
        {
            PatientService = new PatientService(context);
            PrescriptionFileService = new PrescriptionFileService(context);
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
            HttpService = new HttpService();
            Environment = "Local";
        }

      [HttpGet("patients")]
        public IActionResult GetPatients()
        {
            return Ok(PatientService.GetAll());
        }

        [HttpGet("medicinesIsa")]
        public IActionResult GetMedicinesFromIsa()
        {
            return Ok(HttpService.FormMedicineFromIsaRequest().Data);
        }

        [HttpPost]
        public IActionResult Post(EPrescription prescription)
        {         
            if (PrescriptionFileService.SendPrescriptionSftp(prescription)) return Ok();
            return BadRequest();
        }

        [HttpPost("http")]
        public IActionResult PostHttp(EPrescription prescription)
        {
            if (PrescriptionFileService.SendPrescriptionHttp(prescription)) return Ok();
            return BadRequest();
        }

        [HttpGet("http/description/{medicine}")]
        public IActionResult GetMedicineDescription(String medicine)
        {
            String medicineDescription = HttpService.GetMedicineDescriptionFromApi(medicine);
            if (medicineDescription.IsNullOrEmpty()) return GetMedicineDescriptionFromIsaHttpAsync(medicine);
            return Ok(medicineDescription);
        }

        public IActionResult GetMedicineDescriptionFromIsaHttpAsync(string medicine)
        {
            String description = HttpService.FormMedicineDescriptionRequest(medicine);
            _ = HttpService.CreateNewMedicineWithQuantityAsync(medicine, description);
            if (description.Length != 0) return Ok(description);
            return BadRequest();
        }
       
        [HttpGet("grpc/description/{medicine}")]
        public IActionResult GetMedicineDescriptionGrpc(string medicine)
        {
            String medicineDescription = HttpService.GetMedicineDescriptionFromApi(medicine);
            if (medicineDescription.IsNullOrEmpty())return GetMedicineDescriptionFromIsaGrpc(medicine);
            return Ok(medicineDescription);
        }

        private IActionResult GetMedicineDescriptionFromIsaGrpc(string medicine)
        {
            string response = new ClientScheduledService().SendMessage(medicine).Result;
            _ = HttpService.CreateNewMedicineWithQuantityAsync(medicine, response);
            return Ok(response);
        }

        [HttpGet("http/medicineAvailability/{medicine}")]
        public IActionResult GetMedicineAvailability(String medicine)
        {
            List<MedicineName> pharmaciesWithMedicine = MedicineAvailabilityTable.FormMedicineAvailability(HttpService.FormMedicineAvailabilityRequest(medicine));
            if (pharmaciesWithMedicine == null) return BadRequest();
            return Ok(pharmaciesWithMedicine);
        }
    }
}
