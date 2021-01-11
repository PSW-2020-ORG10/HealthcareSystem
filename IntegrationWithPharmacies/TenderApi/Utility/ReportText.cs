using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using TenderApi.DbContextModel;
using TenderApi.Model;
using TenderApi.Service;

namespace TenderApi.Utility
{
    public class ReportText
    {
        public MyDbContext DbContext;
        private HelperFunctions HelperFunctions { get; }
        private TenderService TenderService { get; }
        private MedicineForTenderingService MedicineForTenderingService { get; }

        public ReportText(MyDbContext context)
        {
            HelperFunctions = new HelperFunctions();
            TenderService = new TenderService(context);
            MedicineForTenderingService = new MedicineForTenderingService(context);
        }
        public ReportText()
        {
            DbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public String GetRegistredPharmacies()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (RegistrationInPharmacy registration in HttpRequests.GetRegistrationsInPharmaciesAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            return stringBuilder.ToString();
        }

        public String getReportText(DateOfOrder date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;

            foreach (Tender tender in TenderService.GetAll())
            {
                getText(date, tender, stringBuilder);
                totalQuatity += getQuantity(date, tender);
            }
            return stringBuilder.Append("\n\n   Total ordered quatity: " + totalQuatity + "\n").ToString();
        }

        public String getText(DateOfOrder date, Tender tender, StringBuilder stringBuilder)
        {
            foreach (MedicineForTendering medicine in MedicineForTenderingService.GetAll())
            {
                if (isOrderInRequiredPeriod(medicine, date, tender))
                {
                    stringBuilder.Append("\n     Medicine name: " + medicine.Name + "\n     Ordered quantity: " + medicine.Quantity + " (Date:  " + tender.ExpirationDate.ToString() + ")\n");
                }
            }
            return stringBuilder.ToString();
        }
        private int getQuantity(DateOfOrder date, Tender tender)
        {
            return MedicineForTenderingService.GetAll().Where(medicine => isOrderInRequiredPeriod(medicine, date, tender)).Sum(medicine => medicine.Quantity);
        }
        private bool isOrderInRequiredPeriod(MedicineForTendering medicine, DateOfOrder date, Tender tender)
        {
            if (HelperFunctions.IsIdEqual(medicine.TenderId, tender.Id) && HelperFunctions.CompareDates(tender.ExpirationDate, HelperFunctions.ConvertStringToDate(date.StartDate)) == 1 && HelperFunctions.CompareDates(tender.ExpirationDate, HelperFunctions.ConvertStringToDate(date.EndDate)) == -1 && tender.Closed) return true;
            return false;
        }
        
    }
}
