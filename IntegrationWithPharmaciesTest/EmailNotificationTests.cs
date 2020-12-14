using Shouldly;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class EmailNotificationTests
    {
        [Fact]
        public void Sends_notification_email()
        {
            Boolean ok = sendNotigication();
            ok.ShouldBe(true);
        }
        [Fact]
        public void Sends_no_notification_email()
        {
            Boolean ok = sendNoNotigication();
            ok.ShouldBe(false);
        }

        private Boolean sendNotigication()
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
        private Boolean sendNoNotigication()
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
