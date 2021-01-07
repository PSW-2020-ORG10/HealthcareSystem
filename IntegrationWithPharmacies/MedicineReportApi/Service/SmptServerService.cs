using System;
using System.Net.Mail;
using System.Net.Mime;

namespace MedicineReportApi.Service
{
    public class SmptServerService
    {
        public SmptServerService() { }

        public void SendEMailNotification(String filePath)
        {
            try { SendMail(filePath); }
            catch (SmtpException exception) { Console.WriteLine(exception.Message); }
        }

        private static void SendMail(String filePath)
        {
            SmtpClient SmptServer = FormSmptServerInformation();
            SmptServer.Send(CreateMailMessage(filePath));
        }

        private static SmtpClient FormSmptServerInformation()
        {
            SmtpClient SmptServer = new SmtpClient("smtp.gmail.com", 587);
            SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
            SmptServer.EnableSsl = true;
            return SmptServer;
        }

        private static MailMessage CreateMailMessage(String filePath)
        {
            MailMessage message = new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about new report about medicine consumption", "Body of mail address");
            message.Attachments.Add(new Attachment(filePath, MediaTypeNames.Application.Octet));
            return message;
        }
    }
}
