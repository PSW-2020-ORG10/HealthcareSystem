
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private String Environment { get; set; }
        private ReportService ReportService { get; set; }
        private DoctorOrderService DoctorOrderService { get; set; }
        private MedicineForOrderingService MedicineService { get; set; }
        private RegistrationInPharmacyService RegistrationInPharmacyService { get; set; }

        public ReportController(MyDbContext context)
        {
            ReportService = new ReportService();
            MedicineService = new MedicineForOrderingService(context);
            DoctorOrderService = new DoctorOrderService(context);
            RegistrationInPharmacyService = new RegistrationInPharmacyService(context);
            Environment = "Local";
        }


        [HttpPost]
        public IActionResult Post(DateOfOrder date)
        {
            if (Environment.Equals("Local"))
            {
                return writeInFileSftp(date);
            }
            return BadRequest();
        }

        private IActionResult writeInFileSftp(DateOfOrder date)
        {
            var sftpService = new SftpService(new NullLogger<SftpService>(), getConfig());
            String complete = @"FileReports\..\Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + getRandomNumber() + ".txt";
            StringBuilder stringBuilder = new StringBuilder();

            return writeReportSftp(date, sftpService, complete, stringBuilder);
        }

        private IActionResult writeReportSftp(DateOfOrder date, SftpService sftpService, string complete, StringBuilder stringBuilder)
        {
            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyService.GetAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            System.IO.File.WriteAllText(complete, stringBuilder.ToString() + "!    Report about consumption of medicine\n\n\n" + getReportText(date));
            sftpService.UploadFile(complete, @"\pub\" + complete);
            SendNotificationAboutReport();
            return Ok();
        }

        public int getRandomNumber()
        {
            return new Random().Next(1, 100);
        }
        [HttpPost("http")]
        public IActionResult PostHttp(DateOfOrder date)
        {
            if (Environment.Equals("Development"))
            {
                return writeInFileHttp(date);
            }
            return BadRequest();
        }

        private IActionResult writeInFileHttp(DateOfOrder date)
        {
            var testFile = @"..\test.txt";
            String complete = @"FileReports\..\Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + getRandomNumber() + ".txt";
            StringBuilder stringBuilder = new StringBuilder();

            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyService.GetAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            return writeReportHttp(date, testFile, complete, stringBuilder);
        }

        private IActionResult writeReportHttp(DateOfOrder date, string testFile, string complete, StringBuilder stringBuilder)
        {
            System.IO.FileStream fs = System.IO.File.Create(complete);
            fs.Close();
            System.IO.File.WriteAllText(complete, stringBuilder.ToString() + "!    Report about consumption of medicine\n\n\n" + getReportText(date));
            try
            {
                uploadFile(complete);
                return Ok(JsonConvert.SerializeObject(testFile));
            }
            catch (Exception e) { return BadRequest(); }
        }

        public void uploadFile(String complete)
        {
               WebClient client = new WebClient();
               client.Credentials = CredentialCache.DefaultCredentials;
               client.UploadFile(new Uri(@"http://localhost:8082/download/file/http"), "POST", complete);
               client.Dispose();
               SendNotificationAboutReport();
        }

        private String getReportText(DateOfOrder date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;
            int i = 1;
           
            foreach (DoctorsOrder order in DoctorOrderService.GetAll())
            {
                stringBuilder.Append(getText(date, order, stringBuilder));
                totalQuatity += getQuantity(date, totalQuatity, order);
                i++;
            }
            return stringBuilder.Append("\n\n   Total ordered quatity: " + totalQuatity + "\n").ToString();
        }

        private String getText(DateOfOrder date, DoctorsOrder order, StringBuilder stringBuilder)
        {
            foreach (MedicineForOrdering medicine in MedicineService.GetAll())
            {
                if (isOrderInRequiredPeriod(medicine, date, order))
                {
                    stringBuilder.Append("\n     Medicine name: " + medicine.Name + "\n     Ordered quantity: " + medicine.Quantity + " (Date:  " + order.DateEnd.Date.ToString() + ")\n");
                }
            }
            return stringBuilder.ToString();
        }
        private int getQuantity(DateOfOrder date, int totalQuatity, DoctorsOrder order)
        {
            return MedicineService.GetAll().Where(medicine => isOrderInRequiredPeriod(medicine, date, order)).Sum(medicine => medicine.Quantity);
        }
        private bool isOrderInRequiredPeriod(MedicineForOrdering medicine, DateOfOrder date, DoctorsOrder order)
        {
            if (isIdEqual(medicine.OrderId, order.id) && compareDates(order.DateEnd, convertStringToDate(date.StartDate)) == 1 && compareDates(order.DateEnd, convertStringToDate(date.EndDate)) == -1 && order.IsFinished) return true;
            return false;
        }
        private bool isIdEqual(int firstNumber, int secondNumber)
        {
            return (firstNumber == secondNumber);
        }
        private int compareDates(DateTime startDate, DateTime endDate)
        {
            return (DateTime.Compare(startDate, endDate));
        }
        private DateTime convertStringToDate(String date)
        {
            return new DateTime(int.Parse(date.Split("/")[2]), int.Parse(date.Split("/")[1]), int.Parse(date.Split("/")[0]));
        }
        private SftpConfig getConfig()
        {
            return new SftpConfig { Host = "192.168.1.244", Port = 22, UserName = "tester", Password = "password" };
        }
        public void SendNotificationAboutReport()
        {
            try {sendMail();}
            catch (SmtpException exception) { Console.WriteLine(exception.Message); }

        }

        private static void sendMail()
        {
            MailMessage mail = new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about send file", "Body of mail address");
            SmtpClient SmptServer = new SmtpClient("smtp.gmail.com",587);
            SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
            SmptServer.EnableSsl = true;
            SmptServer.Send(mail);
        }
    }

}