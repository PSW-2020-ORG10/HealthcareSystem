using System;
using System.Net.Mail;
using System.Text;
using UrgentMedicineOrderApi.Model;

namespace UrgentMedicineOrderApi.Service
{
    public class SmptServerService
    {
        public SmptServerService() { }
        public void SendEMailNotificationForUrgentOrdee(UrgentMedicineOrder urgentMedicineOrder, string pharmacyName)
        {
            try { SendMail(urgentMedicineOrder, pharmacyName); }
            catch (SmtpException exception) { Console.WriteLine(exception.Message); }
        }
        private static void SendMail(UrgentMedicineOrder urgentMedicineOrder, String pharmacyName)
        {
            SmtpClient smptServer = FormSmptServerInformation();
            smptServer.Send(CreateMailMessage(urgentMedicineOrder, pharmacyName));
        }

        private static SmtpClient FormSmptServerInformation()
        {
            SmtpClient smptServer = new SmtpClient("smtp.gmail.com", 587);
            smptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
            smptServer.EnableSsl = true;
            return smptServer;
        }

        private static MailMessage CreateMailMessage(UrgentMedicineOrder urgentMedicineOrder, String pharmacyName)
        {
            return new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about urgent medicine order", FormBodyOfMailMessage(urgentMedicineOrder, pharmacyName));
        }

        private static string FormBodyOfMailMessage(UrgentMedicineOrder urgentMedicineOrder, string pharmacyName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Medicine is ordered from: " + pharmacyName + "\n" + "Requested medicine: " + urgentMedicineOrder.Name + ", quantity:  " + urgentMedicineOrder.Quantity + " \n");
            return stringBuilder.ToString();
        }

    }
}
