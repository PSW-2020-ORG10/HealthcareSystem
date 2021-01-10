using System.Net.Mail;

namespace UserMicroserviceApi.Service
{
    public interface IEmailVerificationService
    {
        void SendVerificationMail(MailAddress recipientMail, int id);
    }
}