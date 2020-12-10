using System;
using System.Net;
using System.Text;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SharingPrescriptionController : Controller
    {
        private MedicineService MedicineService { get; set; }
        private PatientService PatientService { get; set; }
        public SharingPrescriptionController(MyDbContext context)
        {
            MedicineService = new MedicineService(context);
            PatientService = new PatientService(context);
        }

        [HttpGet("patients")]
        public IActionResult GetPatients()
        {
            return Ok(PatientService.GetAll());
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
        [HttpPost("http")]
        public IActionResult PostHttp(Prescription prescription)
        {

            var testFile = @"..\test.txt";
            String newFile = @"Prescription;" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            String complete = @"FilePrescriptions\..\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            StringBuilder stringBuilder = new StringBuilder();

           
            System.IO.FileStream fs = System.IO.File.Create(complete);
            fs.Close();
            stringBuilder.Append("          Precription for medicine\n\n");
            stringBuilder.Append("Patients name: " + prescription.Name + "\n");
            stringBuilder.Append("Patients surname: " + prescription.Surname + "\n");
            stringBuilder.Append("Patients medical ID number: " + prescription.MedicalIDNumber + "\n");
            stringBuilder.Append("Medication: " + prescription.Medicine + "     ");
            stringBuilder.Append("Quantity: " + prescription.Quantity + "\n");
            stringBuilder.Append("Usage: " + prescription.Usage + "\n");
            System.IO.File.WriteAllText(complete, stringBuilder.ToString());



            try
            {

                WebClient client = new WebClient();
                Uri uri = new Uri(@"http://localhost:8082/download/prescription/http");
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UploadFile(uri, "POST", complete);
                client.Dispose();


                return Ok(JsonConvert.SerializeObject(testFile));
            }
            catch (Exception e)
            {

            }
            return Ok();
        }

    }
}
