using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
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
        }


        [HttpPost]
        public IActionResult Post(DateOfOrder date)
        {
            var sftpService = new SftpService(new NullLogger<SftpService>(), getConfig());
            var testFile = @"..\test.txt";
            StringBuilder stringBuilder = new StringBuilder();

            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyService.GetAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            System.IO.File.WriteAllText(testFile, stringBuilder.ToString() + "!    Report about consumption of medicine\n\n\n" +getReportText(date));
            sftpService.UploadFile(testFile, @"\pub\" + Path.GetFileName(testFile));
            return Ok();
        }
      
        [HttpPost("http")]
        public IActionResult PostHttp(DateOfOrder date)
        {
            
            var testFile = @"..\test.txt";
            StringBuilder stringBuilder = new StringBuilder();

            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyService.GetAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            System.IO.File.WriteAllText(testFile, stringBuilder.ToString() + "!    Report about consumption of medicine\n\n\n" + getReportText(date));
            Console.WriteLine("*******************       1           *****************************");
            try
            {
                Console.WriteLine("*******************       2           *****************************");

                WebClient client = new WebClient();
                Console.WriteLine("*******************      3          *****************************");
                Uri uri = new Uri(@"http://localhost:8082/download/file/http");
                Console.WriteLine("*******************      4          *****************************");
                client.Credentials = CredentialCache.DefaultCredentials;
                Console.WriteLine("*******************      5          *****************************");
                client.UploadFile(uri, "POST", @"..\TextFile.txt");
                Console.WriteLine("*******************      6          *****************************");
                client.Dispose();
                Console.WriteLine("*******************      7          *****************************");

            
                return Ok(JsonConvert.SerializeObject(testFile));
            }
            catch(Exception e) {
                Console.WriteLine("**********************************************************");

            }
            return Ok();
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
            return new SftpConfig { Host = "192.168.56.1", Port = 22, UserName = "tester", Password = "password" };
        }
    }


}