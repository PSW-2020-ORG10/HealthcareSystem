using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class ReportText
    {
        public MyDbContext DbContext;
        private RegistrationInPharmacyService RegistrationInPharmacyService { get; }
        private DoctorOrderService DoctorOrderService { get; }
        private MedicineForOrderingService MedicineService { get; }
        private HelperFunctions HelperFunctions { get; }

        public ReportText(MyDbContext context)
        {
            RegistrationInPharmacyService = new RegistrationInPharmacyService(context);
            DoctorOrderService = new DoctorOrderService(context);
            MedicineService = new MedicineForOrderingService(context);
            HelperFunctions = new HelperFunctions();
        }
        public ReportText()
        {
           DbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public String GetRegistredPharmacies()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyService.GetAll())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            return stringBuilder.ToString();
        }

        public String getReportText(DateOfOrder date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;

            foreach (DoctorsOrder order in DoctorOrderService.GetAll())
            {
                stringBuilder.Append(getText(date, order, stringBuilder));
                totalQuatity += getQuantity(date, totalQuatity, order);
            }
            return stringBuilder.Append("\n\n   Total ordered quatity: " + totalQuatity + "\n").ToString();
        }

        public String getText(DateOfOrder date, DoctorsOrder order, StringBuilder stringBuilder)
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
            if (HelperFunctions.IsIdEqual(medicine.OrderId, order.id) && HelperFunctions.CompareDates(order.DateEnd, HelperFunctions.ConvertStringToDate(date.StartDate)) == 1 && HelperFunctions.CompareDates(order.DateEnd, HelperFunctions.ConvertStringToDate(date.EndDate)) == -1 && order.IsFinished) return true;
            return false;
        }
    }
}
