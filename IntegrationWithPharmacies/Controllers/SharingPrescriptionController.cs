using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
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
        public IActionResult Post(Prescription prescription)
        {
            Random random = new Random();
            int number = random.Next(1, 100);
            var testFile = @"..\test.txt";
            var sftpService = new SftpService(new NullLogger<SftpService>(), getConfig());
            String newFile = @"Prescription;" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + number+ ".txt";
            String complete = @"FilePrescriptions\..\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") +"_" +number + ".txt";
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

            sftpService.UploadFile(testFile, @"\pub\" + complete);
            SendNotificationAboutReport();
            return Ok();
        }
        [HttpPost("http")]
        public IActionResult PostHttp(Prescription prescription)
        {
            Random random = new Random();
            int number = random.Next(1, 100);
            var testFile = @"..\test.txt";
            String newFile = @"Prescription;" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + number + ".txt";
            String complete = @"FilePrescriptions\..\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + number + ".txt";
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
                SendNotificationAboutReport();
                return Ok(JsonConvert.SerializeObject(testFile));
            }
            catch (Exception e)
            {

            }
            return Ok();
        }

        public void SendNotificationAboutReport()
        {
            try
            {
                Console.WriteLine("SALJE MEJL");
                MailMessage mail = new MailMessage();
                SmtpClient SmptServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("ourhospital9@gmail.com");
                mail.To.Add("pharmacyisa@gmail.com");
                mail.Subject = "Notification about send file";
                mail.Body = "Body of mail address";

                SmptServer.Port = 587;
                SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
                SmptServer.EnableSsl = true;


                SmptServer.Send(mail);


            }
            catch (SmtpException ex) {
                Console.WriteLine("NE SALJE MEJL");
            }

        }
        private SftpConfig getConfig()
        {
            return new SftpConfig { Host = "192.168.1.244", Port = 22, UserName = "tester", Password = "password" };
        }

    }
}
