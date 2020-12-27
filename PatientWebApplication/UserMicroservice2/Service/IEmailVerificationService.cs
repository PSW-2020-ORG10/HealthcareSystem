using System.Net.Mail;

namespace UserMicroservice.Service
{
    public interface IEmailVerificationService
    {
        void SendVerificationMail(MailAddress recipientMail, int id);
    }
}