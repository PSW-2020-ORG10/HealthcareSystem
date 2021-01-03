using System.Collections.Generic;
using UserMicroserviceApi.Model;

namespace HealthClinic.CL.Repository
{
    public interface IMessageRepository
    {
        Message Create(Message message);

        List<Message> GetAll();
    }
}