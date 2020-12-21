using System;
using System.Net.Mail;
using System.Net.Mime;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class SmptServerService
    {
        public SmptServerService() { }

        public void SendEMailNotification(String filePath, String type)
        {
            try { SendMail(filePath,type); }
            catch (SmtpException exception) { Console.WriteLine(exception.Message); }
        }

        private static void SendMail(String filePath, String type)
        {
            SmtpClient SmptServer = new SmtpClient("smtp.gmail.com", 587);
            SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
            SmptServer.EnableSsl = true;
            SmptServer.Send(CreateMailMessage(filePath, type));
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
