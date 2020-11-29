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
        private ReportService reportService { get; set; }
        private DoctorOrderRepository orderRepository { get; set; }
        private MedicineForOrderingService medicineService { get; set; }

        public ReportController(MyDbContext context)
        {
            reportService = new ReportService();
            medicineService = new MedicineForOrderingService(context);
            orderRepository = new DoctorOrderRepository(context);
        }

        [HttpPost]   // GET /api/registration
        public IActionResult Post(DateTime startDate,DateTime endDate)
        {

            var config = new SftpConfig
            {
                Host = "192.168.0.28",
                Port = 22,
                UserName = "tester",
                Password = "password"
            };
            var sftpService = new SftpService(new NullLogger<SftpService>(), config);
            StringBuilder sb = new StringBuilder();
            int totalQuatity = 0;
            sb.Append("Report about consumption of medicine\n\n\n");
            int i = 1;
            
                foreach (DoctorsOrder order in orderRepository.GetAll())
                {
                     foreach (MedicineForOrdering medicine in medicineService.GetAll())
                        {
                            if (medicine.orderId.Equals(order.id))
                            {
                                if (order.isFinished)
                                {
                                    sb.Append(i + ".\n");
                                    sb.Append("     Medicine name: " + medicine.name + "\n");
                                    sb.Append("     Ordered quantity: " + medicine.quantity + " (Date:  " + order.dateStart.Date + ")\n");

                                    totalQuatity += medicine.quantity;
                                    i++;
                        }

                            }
                   
                }
                

            }
            sb.Append("\n\n   Total ordered quatity: " + totalQuatity + "\n");
            String reportText = sb.ToString();
            var testFile = @"C:\Users\Mladenka\Desktop\psw\HealthcareSystem\IntegrationWithPharmacies\TextFile.txt";
            System.IO.File.WriteAllText(testFile, reportText);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            sftpService.UploadFile(testFile, @"\pub\" + Path.GetFileName(testFile));
            return Ok();
        }


    }
}