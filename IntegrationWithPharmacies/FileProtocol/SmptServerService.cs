using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class SmptServerService
    {
        public SmptServerService() { }

        public void SendEMailNotification(String filePath, String type)
        {
            try { SendMail(filePath, type); }
            catch (SmtpException exception) { Console.WriteLine(exception.Message); }
        }

        public void SendEMailNotificationForTender(List<MedicineTenderOffer> medicinesWithQuantity, string pharmacyApi)
        {
            try { SendMailForTender(getEmailText(medicinesWithQuantity,pharmacyApi)); }
            catch (SmtpException exception) { Console.WriteLine(exception.Message); }
        }

        private void SendMailForTender(string emailInformation)
        {
            SmtpClient SmptServer = FormSmptServerInformation();
            SmptServer.Send(CreateMailMessageForTender(emailInformation));

        }

        private MailMessage CreateMailMessageForTender(string emailInformation)
        {
            return new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about tender", emailInformation);
        }

        private String getEmailText(List<MedicineTenderOffer> medicinesWithQuantity, string pharmacyApi)
        {
            return InformationAboutEveryMedicineInTender(medicinesWithQuantity, BasicEmailTenderInformation(pharmacyApi)).ToString();
        }

        private static StringBuilder BasicEmailTenderInformation(string pharmacyApi)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Winner of tender is pharmacy with api key : " + pharmacyApi +"\n"+ "Requested medicines:    Name  /  Quantity  /  Price\n");
            return stringBuilder;
        }

        private static StringBuilder InformationAboutEveryMedicineInTender(List<MedicineTenderOffer> medicinesWithQuantity, StringBuilder stringBuilder)
        {
            foreach (MedicineTenderOffer medicineTenderOffer in medicinesWithQuantity)
            {
                stringBuilder.Append(medicineTenderOffer.MedicineName + "  /  " + medicineTenderOffer.AvailableQuantity + "  /  " + medicineTenderOffer.Price + "\n");
            }
            return stringBuilder;
        }

        private static void SendMail(String filePath, String type)
        {
            SmtpClient SmptServer = FormSmptServerInformation();
            SmptServer.Send(CreateMailMessage(filePath, type));
        }
   
        private static SmtpClient FormSmptServerInformation()
        {
            SmtpClient SmptServer = new SmtpClient("smtp.gmail.com", 587);
            SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
            SmptServer.EnableSsl = true;
            return SmptServer;
        }

        private static MailMessage CreateMailMessage(String filePath, String type)
        {
            MailMessage message = GetMessageInformation(type);
            message.Attachments.Add(new Attachment(filePath, MediaTypeNames.Application.Octet));
            return message;
        }

        private static MailMessage GetMessageInformation(string type)
        {
            if (type.Equals("report")) return new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about new report about medicine consumption", "Body of mail address");
            return new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about new prescription", "Body of mail address");
        }

      
    }
}
