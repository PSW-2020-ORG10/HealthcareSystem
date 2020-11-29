using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private ReportService ReportService { get; set; }
        private DoctorOrderServica DoctorOrderService { get; set; }
        private MedicineForOrderingService MedicineService { get; set; }

        public ReportController(MyDbContext context)
        {
            ReportService = new ReportService();
            MedicineService = new MedicineForOrderingService(context);
            DoctorOrderService = new DoctorOrderServica(context);
        }


        [HttpPost]
        public IActionResult Post(DateOfOrder date)
        {
            var sftpService = new SftpService(new NullLogger<SftpService>(), getConfig());
            var testFile = @"..\TextFile.txt";
            System.IO.File.WriteAllText(testFile, getReportText(date));
            sftpService.UploadFile(testFile, @"\pub\" + Path.GetFileName(testFile));
            return Ok();
        }

        private String getReportText(DateOfOrder date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;
            int i = 1;
            stringBuilder.Append("Report about consumption of medicine\n\n\n");
            foreach (DoctorsOrder order in DoctorOrderService.GetAll())
            {
                stringBuilder.Append(getText(date, order,stringBuilder));
                totalQuatity += getQuantity(date, totalQuatity, order);
                i++;
            }
            return stringBuilder.Append("\n\n   Total ordered quatity: " + totalQuatity + "\n").ToString();
        }

        private String getText(DateOfOrder date, DoctorsOrder order,StringBuilder stringBuilder)
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
            return MedicineService.GetAll().Where(medicine => isOrderInRequiredPeriod(medicine,date,order)).Sum(medicine => medicine.Quantity);
        }
        private bool isOrderInRequiredPeriod(MedicineForOrdering medicine,DateOfOrder date, DoctorsOrder order)
        {
            if (isIdEqual(medicine.OrderId,order.id) && compareDates(order.DateEnd, convertStringToDate(date.StartDate))==1 && compareDates(order.DateEnd, convertStringToDate(date.EndDate))==-1 && order.IsFinished) return true;
            return false;
        }
        private bool isIdEqual(int firstNumber,int secondNumber)
        {
            return(firstNumber == secondNumber);
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
            return new SftpConfig { Host = "192.168.0.28", Port = 22, UserName = "tester", Password = "password" };
        }
    }


}