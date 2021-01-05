using System.IO;
using System.Net;
using System.Net.Mail;
using UserMicroserviceApi.DbContextModel;

namespace UserMicroserviceApi.Service
{
    public class EmailVerificationService : IEmailVerificationService
    {
        private MyDbContext dbContext;

        public EmailVerificationService(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SendVerificationMail(MailAddress recipientMail, int id)
        {
            MailAddress senderAddress = new MailAddress("healthclinicpsw@gmail.com");
            SmtpClient smtp = CreateClient(senderAddress);
            MailMessage message = CreateMessage(senderAddress, recipientMail, id);
            message.IsBodyHtml = true;
            smtp.Send(message);
        }

        private SmtpClient CreateClient(MailAddress senderAddress)
        {
            string senderPassword = "firma10psw";
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderAddress.Address, senderPassword)
            };
        }

        private MailMessage CreateMessage(MailAddress senderAddress, MailAddress recipientAddress, int id)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\UserMicroserviceApi\\Html for mail\\verMail1.html";
            string body = File.ReadAllText(path);
            body = body.Replace("#PatientId#", id.ToString());
            return new MailMessage(senderAddress, recipientAddress)
            {
                Subject = "Verification of HealthClinic account.",
                Body = body
            };
        }
    }
}
