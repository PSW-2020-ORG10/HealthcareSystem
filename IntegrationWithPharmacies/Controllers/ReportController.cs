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
        public DateTime convertStringToDate(String date)
        {
            String[] parts = date.Split("/");
            return new DateTime(int.Parse(parts[2]),int.Parse(parts[1]), int.Parse(parts[0]));


        [HttpPost]
        public IActionResult Post(DateOfOrder date)
        {
            var sftpService = new SftpService(new NullLogger<SftpService>(), getConfig());
            var testFile = @"..\TextFile.txt";
            System.IO.File.WriteAllText(testFile, getReportText(date));
            sftpService.UploadFile(testFile, @"\pub\" + Path.GetFileName(testFile));
            return Ok();
        }

        public String getReportText(DateOfOrder date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;
            int i = 1;
            stringBuilder.Append("Report about consumption of medicine\n\n\n");
            foreach (DoctorsOrder order in DoctorOrderService.GetAll())
            {
                stringBuilder.Append(getText(date, order, i));
                totalQuatity += getQuantity(date, totalQuatity, order);
                i++;
            }
            return stringBuilder.Append("\n\n   Total ordered quatity: " + totalQuatity + "\n").ToString();
        }

        private String getText(DateOfOrder date, DoctorsOrder order, int i)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (MedicineForOrdering medicine in MedicineService.GetAll())
            {
                if (medicine.OrderId.Equals(order.id) && order.IsFinished && DateTime.Compare(order.DateEnd, convertStringToDate(date.StartDate)) == 1 && DateTime.Compare(order.DateEnd, convertStringToDate(date.EndDate)) == -1)
                {
                    stringBuilder.Append(i + ".\n     Medicine name: " + medicine.Name + "\n     Ordered quantity: " + medicine.Quantity + " (Date:  " + order.DateEnd.Date.ToString() + ")\n");
                }
            }
            return stringBuilder.ToString();
        }
        private int getQuantity(DateOfOrder date, int totalQuatity, DoctorsOrder order)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (MedicineForOrdering medicine in MedicineService.GetAll())
            {
                if (medicine.OrderId.Equals(order.id) && order.IsFinished && DateTime.Compare(order.DateEnd, convertStringToDate(date.StartDate)) == 1 && DateTime.Compare(order.DateEnd, convertStringToDate(date.EndDate)) == -1)
                {
                    totalQuatity += medicine.Quantity;
                }
            }
            return totalQuatity;
        }

        public DateTime convertStringToDate(String date)
        {
            String[] parts = date.Split("/");
            return new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));

        }
        public SftpConfig getConfig()
        {
            return new SftpConfig { Host = "192.168.0.28", Port = 22, UserName = "tester", Password = "password" };
        }
    }


}