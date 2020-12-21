using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.Controllers;
using IntegrationWithPharmacies.FileProtocol;
using Moq;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class FileProtocolTests
    {
        [Fact]
        public static void Sends_file_using_file_protocol()
        {
            var mock = new Mock<ISftpService>();

            var testFile = @"..\test.txt";
            mock.Setup(verify => verify.UploadFile(testFile, @"\pub" + Path.GetFileName(testFile))).Returns(true);

        }
        [Fact]
        public static void Sends_no_file_using_file_protocol()
        {
            var mock = new Mock<ISftpService>();

            var testFile = @"..\wrong.txt";
            mock.Setup(verify => verify.UploadFile(null, @"\pub" + Path.GetFileName(testFile))).Returns(false);

        }

        [Fact]
        public void Generates_file_report()
        {
            DoctorOrderService doctorOrderService = new DoctorOrderService(Create_stub_repository_doctor_orders());
            MedicineForOrderingService medicineForOrderingService = new MedicineForOrderingService(Create_stub_repository_medicine_orders());
            DateOfOrder date = new DateOfOrder("10/09/2020", "25/10/2020");
            string report = getReportText(date, doctorOrderService, medicineForOrderingService);
            Assert.NotEqual("", report);
        }

        [Fact]
        public void Generates_no_file_report()
        {
            DoctorOrderService doctorOrderService = new DoctorOrderService(Create_stub_repository_doctor_orders());
            MedicineForOrderingService medicineForOrderingService = new MedicineForOrderingService(Create_stub_repository_medicine_orders());
            DateOfOrder date = new DateOfOrder("10/09/2022", "25/10/2022");
            string report = getReportText(date, doctorOrderService, medicineForOrderingService);
            Assert.Equal("", report);
        }

        public static IDoctorOrderRepositoy Create_stub_repository_doctor_orders()
        {
            var stubRepository = new Mock<IDoctorOrderRepositoy>();
            DoctorsOrder order1 = new DoctorsOrder(2, false, new DateTime(2020, 3, 12), new DateTime(2020, 9, 9), true, true);
            DoctorsOrder order2 = new DoctorsOrder(3, true, new DateTime(2020, 8, 12), new DateTime(2020, 10, 9), true, true);

            var orders = new List<DoctorsOrder>();
            orders.Add(order1);
            orders.Add(order2);
            stubRepository.Setup(m => m.GetAll()).Returns(orders);
            return stubRepository.Object;
        }
        public static IMedicineForOrderingRepository Create_stub_repository_medicine_orders()
        {
            var stubRepository = new Mock<IMedicineForOrderingRepository>();
            MedicineForOrdering medicine1 = new MedicineForOrdering(2, "Paracetamol", 100, "Paracetamol is a medication used to treat pain and fever.", 2);
            MedicineForOrdering medicine2 = new MedicineForOrdering(3, "Ibuprofen", 80, "Ibuprofen is a medication used for treating pain, fever, and inflammation.", 2);
            MedicineForOrdering medicine3 = new MedicineForOrdering(4, "Clindamycin", 30, "Clindamycin is an antibiotic used for the treatment of a number of bacterial infections.", 2);
            MedicineForOrdering medicine4 = new MedicineForOrdering(5, "Palitrex", 100, ". Palitrex is indicated for the treatment of respiratory  infections.", 2);
            MedicineForOrdering medicine5 = new MedicineForOrdering(6, "Ibuprofen", 80, "Ibuprofen is a medication used for treating pain, fever, and inflammation.", 3);
            MedicineForOrdering medicine6 = new MedicineForOrdering(7, "Jomelop", 25, "Efficiently helps skin heal faster after sun-burns.", 3);
            MedicineForOrdering medicine7 = new MedicineForOrdering(8, "Antiseptics", 200, "Antiseptics substances that are applied to living tissue/skin to reduce the possibility of infection", 3);
            var orders = new List<MedicineForOrdering>();
            orders.Add(medicine1);
            orders.Add(medicine2);
            orders.Add(medicine3);
            orders.Add(medicine4);
            orders.Add(medicine5);
            orders.Add(medicine6);
            orders.Add(medicine7);
            stubRepository.Setup(m => m.GetAll()).Returns(orders);
            return stubRepository.Object;
        }


        private string getReportText(DateOfOrder date, DoctorOrderService doctorOrderService, MedicineForOrderingService medicineForOrderingService)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;
            int i = 1;

            foreach (DoctorsOrder order in doctorOrderService.GetAllForStub())
            {
                stringBuilder.Append(getText(date, order, stringBuilder, medicineForOrderingService));
                totalQuatity += 5;
                i++;
            }
            return stringBuilder.ToString();
        }

        private String getText(DateOfOrder date, DoctorsOrder order, StringBuilder stringBuilder, MedicineForOrderingService medicineForOrderingService)
        {
            foreach (MedicineForOrdering medicine in medicineForOrderingService.GetAllForStub())
            {
                if (isOrderInRequiredPeriod(medicine, date, order))
                {
                    stringBuilder.Append("\n     Medicine name: " + medicine.Name + "\n     Ordered quantity: " + medicine.Quantity + " (Date:  " + order.DateEnd.Date.ToString() + ")\n");
                }
            }
            return stringBuilder.ToString();
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


    }

}
