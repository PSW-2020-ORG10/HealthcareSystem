using Shouldly;
using System;
using System.Net.Mail;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class EmailNotificationTests
    {
        [Fact]
        public void Sends_notification_email()
        {
            sendNotification().ShouldBe(true);
        }
        [Fact]
        public void Sends_no_notification_email()
        {
            sendNoNotification().ShouldBe(false);
        }

        private Boolean sendNotification()
        {
            try
            {
                MailMessage mail = new MailMessage("ourhospital9@gmail.com", "pharmacyisa@gmail.com", "Notification about send file", "Body of mail address");
                SmtpClient SmptServer = new SmtpClient("smtp.gmail.com", 587);
                SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
                SmptServer.EnableSsl = true;
                SmptServer.Send(mail);
                return true;
            }
            catch { return false; }

        }
        private Boolean sendNoNotification()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmptServer = new SmtpClient("smtp.gmail.com", 587);
                SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
                SmptServer.EnableSsl = true;
                SmptServer.Send(mail);
                return true;
            }
            catch { return false; }

        }
    }
}
