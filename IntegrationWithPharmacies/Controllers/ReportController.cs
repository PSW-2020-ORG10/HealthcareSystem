﻿
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

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
            var testFile = @"..\TextFile.txt";
            StringBuilder stringBuilder = new StringBuilder();

            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyService.GetAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            System.IO.File.WriteAllText(testFile, stringBuilder.ToString() + "!    Report about consumption of medicine\n\n\n" + getReportText(date));
            sftpService.UploadFile(testFile, @"\pub\" + Path.GetFileName(testFile));
            return Ok();
        }
      
        [HttpPost("http")]
        public IActionResult PostHttp(DateOfOrder date)
        {
            
            var testFile = @"..\test.txt";
            String newFile = @"Report;" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            String complete = @"FileReports\..\Report_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            StringBuilder stringBuilder = new StringBuilder();

            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyService.GetAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            System.IO.FileStream fs = System.IO.File.Create(complete);
            fs.Close();
            System.IO.File.WriteAllText(complete, stringBuilder.ToString() + "!    Report about consumption of medicine\n\n\n" + getReportText(date));
            Console.WriteLine("*******************       1           *****************************");

            string[] lines = System.IO.File.ReadAllLines(@"..\TextFile.txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            try
            {

                WebClient client = new WebClient();
                Uri uri = new Uri(@"http://localhost:8082/download/file/http");
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UploadFile(uri, "POST", complete);
                client.Dispose();

            
                return Ok(JsonConvert.SerializeObject(testFile));
            }
            catch(Exception e) {
             
            }
            return Ok();
        }


        [HttpGet("http/recieve")]
        public void GetHttpRecieveFile()
        {
            /*var client = new RestSharp.RestClient("http://localhost:8082");
            var request = new RestRequest("/upload/medicine/Panadol");
            Console.WriteLine("**********************    1 ****************************");

            IRestResponse response = client.Get(request);*/
            using (WebClient webClient = new WebClient())
            {
                Console.WriteLine("**********************    2 ****************************");
                //wc.Headers.Add("Cookie: Authentication=user"); // add a cookie header to the request
                try
                {   String filename = "noviPSw.txt";
                    Console.WriteLine("**********************    3 ****************************");
                    //string filename = System.Guid.NewGuid().ToString("N"); // use global unique identifier for file name to avoid conflicts
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri("http://localhost:8082/upload/medicine/Panadol"), @"..\" + filename);
                   // wc.DownloadFile("http://localhost:8082/upload/medicine/{medicine}", @"..\" + filename); // could add file extension here
                    Console.WriteLine("**********************    4 ****************************");                                                                           // do something with file
                }
                catch (System.Exception ex)
                {
                    // check exception object for the error
                }
            }
          

        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("GOTOVO");
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