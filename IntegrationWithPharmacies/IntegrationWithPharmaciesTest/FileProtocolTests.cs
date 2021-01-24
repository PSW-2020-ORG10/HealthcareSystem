using System;
using System.Collections.Generic;
using System.Text;

using Moq;
using TenderApi.Model;
using TenderApi.Repository;
using TenderApi.Service;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class FileProtocolTests
    {
        [Fact]
        public void Generates_file_report()
        {
            TenderService tenderService = new TenderService(Create_stub_repository_tenders());
            MedicineForTenderingService medicineForTenderingService = new MedicineForTenderingService(Create_stub_repository_medicine_tender_orders());
            DateOfOrder date = new DateOfOrder("01/01/2020", "05/10/2020");
            string report = getReportText(date, tenderService, medicineForTenderingService);
            Assert.NotEqual("", report);
        }

        [Fact]
        public void Generates_no_file_report()
        {   
            TenderService tenderService = new TenderService(Create_stub_repository_tenders());
            MedicineForTenderingService medicineForTenderingService = new MedicineForTenderingService(Create_stub_repository_medicine_tender_orders());
            DateOfOrder date = new DateOfOrder("10/09/2022", "25/10/2023");
            string report = getReportText(date, tenderService, medicineForTenderingService);
            Assert.Equal("", report);
        }

        public static ITenderRepository Create_stub_repository_tenders()
        {
            var stubRepository = new Mock<ITenderRepository>();
            Tender tender1 = new Tender(1, new DateTime(2020, 01, 04), true);

            var tenders = new List<Tender>();
            tenders.Add(tender1);
            stubRepository.Setup(m => m.GetAll()).Returns(tenders);
            return stubRepository.Object;
        }
        public static IMedicineForTenderingRepository Create_stub_repository_medicine_tender_orders()
        {
            var stubRepository = new Mock<IMedicineForTenderingRepository>();
            MedicineForTendering medicineForTendering1 = new MedicineForTendering(1, "Brufen", 5, 1);
            MedicineForTendering medicineForTendering2 = new MedicineForTendering(2, "Paracetamol", 5, 1);

            var medicineForTenderings = new List<MedicineForTendering>();
            medicineForTenderings.Add(medicineForTendering1);
            medicineForTenderings.Add(medicineForTendering2);

            stubRepository.Setup(m => m.GetAll()).Returns(medicineForTenderings);
            return stubRepository.Object;
        }


        private string getReportText(DateOfOrder date, TenderService tenderService, MedicineForTenderingService medicineForTenderingService)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;
            int i = 1;

            foreach (Tender tender in tenderService.GetAllForStub())
            {
                stringBuilder.Append(getText(date, tender, stringBuilder, medicineForTenderingService));
                totalQuatity += 5;
                i++;
            }
            return stringBuilder.ToString();
        }

        private String getText(DateOfOrder date, Tender tender, StringBuilder stringBuilder, MedicineForTenderingService medicineForTenderingService)
        {
            foreach (MedicineForTendering medicine in medicineForTenderingService.GetAllForStub())
            {
                if (isOrderInRequiredPeriod(medicine, date, tender))
                {
                    stringBuilder.Append("\n     Medicine name: " + medicine.Name + "\n     Ordered quantity: " + medicine.Quantity + " (Date:  " + tender.ExpirationDate.ToString() + ")\n");
                }
            }
            return stringBuilder.ToString();
        }
        private bool isOrderInRequiredPeriod(MedicineForTendering medicine, DateOfOrder date, Tender tender)
        {
            if (isIdEqual(medicine.TenderId, tender.Id) && compareDates(tender.ExpirationDate, convertStringToDate(date.StartDate)) == 1 && compareDates(tender.ExpirationDate, convertStringToDate(date.EndDate)) == -1 && tender.Closed) return true;
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
