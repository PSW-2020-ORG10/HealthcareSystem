using System.Net.Mail;

namespace HealthClinic.CL.Service
{
    public interface IEmailVerificationService
    {
        void SendVerificationMail(MailAddress recipientMail, int id);
    }
}