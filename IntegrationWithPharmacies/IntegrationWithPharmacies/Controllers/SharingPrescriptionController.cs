using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

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

        public SharingPrescriptionController(MyDbContext context)
        {
            PatientService = new PatientService(context);
            PrescriptionFileService = new PrescriptionFileService(context);
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
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
            String medicineDescription = GetMedicineDescriptionFromApi(medicine);
            if (medicineDescription.IsNullOrEmpty()) return GetMedicineDescriptionFromIsaHttpAsync(medicine);
            return Ok(medicineDescription);
        }

        private static String GetMedicineDescriptionFromApi(String medicine)
        {
            var client = new RestSharp.RestClient("http://localhost:54679");
            var description = client.Get<String>(new RestRequest("/api/medicineWithQuantity/description/"+medicine));
            return description.Data;
        }

        public IActionResult GetMedicineDescriptionFromIsaHttpAsync(string medicine)
        {
            String description = HttpService.FormMedicineDescriptionRequest(medicine);
            _ = CreateNewMedicineWithQuantityAsync(medicine, description);
            if (description.Length != 0) return Ok(description);
            return BadRequest();
        }
        private async Task CreateNewMedicineWithQuantityAsync(String medicine, String description)
        {
            var values = new Dictionary<string, object>
            {
                { "name", medicine }, { "quantity",  0}, { "description", description}
            };
            var content = new StringContent(JsonConvert.SerializeObject(values, Formatting.Indented), Encoding.UTF8, "application/json");
            using HttpClient client = new HttpClient();
            await client.PostAsync("http://localhost:54679/api/medicineWithQuantity", content);
        }
        [HttpGet("grpc/description/{medicine}")]
        public IActionResult GetMedicineDescriptionGrpc(string medicine)
        {
            String medicineDescription = GetMedicineDescriptionFromApi(medicine);
            if (medicineDescription.IsNullOrEmpty())return GetMedicineDescriptionFromIsaGrpc(medicine);
            return Ok(medicineDescription);
        }

        private IActionResult GetMedicineDescriptionFromIsaGrpc(string medicine)
        {
            string response = new ClientScheduledService().SendMessage(medicine).Result;
            _ = CreateNewMedicineWithQuantityAsync(medicine, response);
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
