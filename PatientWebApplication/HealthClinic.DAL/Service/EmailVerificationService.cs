using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class EmailVerificationService : IEmailVerificationService
    {
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
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\HealthClinic.DAL\\Html for mail\\verMail1.html";
            string body = System.IO.File.ReadAllText(path);
            body = body.Replace("#PatientId#", id.ToString());
            return new MailMessage(senderAddress, recipientAddress)
            {
                Subject = "Verification of HealthClinic account.",
                Body = body
            };
        }
    }
}
