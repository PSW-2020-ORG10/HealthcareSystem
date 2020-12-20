using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using RestSharp;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SharingPrescriptionController : Controller
    {
        private String Environment { get; set; }
        private MedicineService MedicineService { get; set; }
        private PatientService PatientService { get; set; }
        public SharingPrescriptionController(MyDbContext context)
        {
            MedicineService = new MedicineService(context);
            PatientService = new PatientService(context);
            Environment = "Development"; 
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

        [HttpGet("medicinesIsa")]
        public IActionResult GetMedicinesFromIsa()
        {
            var client = new RestSharp.RestClient("http://localhost:8082");
            var response = client.Get<List<MedicineName>>(new RestRequest("/medicineRequested"));
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            response.Data.ForEach(medicine => Console.WriteLine(medicine.ToString()));
            return Ok(response.Data);
        }

        [HttpPost]
        public IActionResult Post(Prescription prescription)
        {
            if (Environment.Equals("Local")) return sendPrescriptionSftp(prescription);
            return BadRequest();
        }

        private IActionResult sendPrescriptionSftp(Prescription prescription)
        {
            var sftpService = new SftpService(new NullLogger<SftpService>(), getConfig());
            String complete = @"FilePrescriptions\..\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + getRandomNumber() + ".txt";
            System.IO.FileStream fs = System.IO.File.Create(complete);
            fs.Close();
            System.IO.File.WriteAllText(complete, getTextForPrescription(prescription));
            sftpService.UploadFile(@"..\test.txt", @"\pub\" + complete);
            SendNotificationAboutReport();
            return Ok();
        }

        [HttpGet("http/recieve/{medicine}")]
        public IActionResult GetMedicineDescription(string medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8082/upload/medicine/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream response = webResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(response, System.Text.Encoding.GetEncoding("utf-8"));
            string description = readStream.ReadToEnd();
            if (description.Length != 0) return Ok(description);
            return BadRequest();
            
        }
        [HttpGet("http/medicineAvailability/{medicine}")]
        public IActionResult GetMedicineAvailability(String medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8082/medicinePharmacy/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream response = webResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(response, System.Text.Encoding.GetEncoding("utf-8"));
            return FormMedicineAvailability(readStream.ReadToEnd());
        }

        private IActionResult FormMedicineAvailability(string availability)
        {
            if (availability.Length > 5) return GetMedicineAvailabilityTable(availability);
            return BadRequest();    
        }

        private IActionResult GetMedicineAvailabilityTable(string availability)
        {
            List<MedicineName> medicines = new List<MedicineName>();
            String[] fileParts = availability.Split(";");
            if (fileParts.Length == 0) GetOnlyOnePharmacy(availability, medicines);
            else GetAllPharmacies(medicines, fileParts);
            return Ok(medicines);
        }

        private static void GetAllPharmacies(List<MedicineName> medicines, string[] fileParts)
        {
            for (int i = 0; i < fileParts.Length; i++)
            {
                String[] nameParts = fileParts[i].Split("_");
                medicines.Add(new MedicineName("Pharmacy: " + nameParts[0] + ", city: " + nameParts[1], nameParts[2]));
            }
        }

        private static void GetOnlyOnePharmacy(string availability, List<MedicineName> medicines)
        {
            String[] nameParts = availability.Split("_");
            medicines.Add(new MedicineName("Pharmacy: " + nameParts[0] + ", city: " + nameParts[1], nameParts[2]));
        }

        private int getRandomNumber()
        {
            return new Random().Next(1, 100);
        }
        private String getTextForPrescription(Prescription prescription)
        {
            return prescription.Pharmacy + " Precription for medicine\n\nPatients name: " + prescription.Name + "\nPatients surname: " + prescription.Surname + "\nPatients medical ID number: " + prescription.MedicalIDNumber + "\nMedication: " + prescription.Medicine + " Quantity: " + prescription.Quantity + "\nUsage: " + prescription.Usage + "\n";
        }
        [HttpPost("http")]
        public IActionResult PostHttp(Prescription prescription)
        {
            if (Environment.Equals("Development"))return sendPrescriptionHttp(prescription);
            return BadRequest();
        }

        private IActionResult sendPrescriptionHttp(Prescription prescription)
        {
            String complete = @"FilePrescriptions\..\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + getRandomNumber() + ".txt";
            System.IO.FileStream fs = System.IO.File.Create(complete);
            fs.Close();
            System.IO.File.WriteAllText(complete, getTextForPrescription(prescription));
            try
            {   uploadFile(complete);
                return Ok();
            }
            catch (Exception e) { return BadRequest(); }
           
        }

        public void uploadFile(String complete)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadFile(new Uri(@"http://localhost:8082/download/prescription/http"), "POST", complete);
            client.Dispose();
            SendNotificationAboutReport();
        }

        public void SendNotificationAboutReport()
        {
            try { sendEmail();  }
            catch (SmtpException ex) { Console.WriteLine(ex.Message); }
        }

        private static void sendEmail()
        {   SmtpClient SmptServer = new SmtpClient("smtp.gmail.com",587);
            SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
            SmptServer.EnableSsl = true;
            SmptServer.Send(GetMailInformation());
        }

        private static MailMessage GetMailInformation()
        {
            return new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about sent file", "Body of mail address");
        }

        private SftpConfig getConfig()
        {
            return new SftpConfig { Host = "192.168.1.244", Port = 22, UserName = "tester", Password = "password" };
        }

    }
}
