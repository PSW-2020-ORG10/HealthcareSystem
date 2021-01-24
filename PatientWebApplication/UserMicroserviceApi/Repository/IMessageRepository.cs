using System.Collections.Generic;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public interface IMessageRepository
    {
        Message Create(Message message);
        List<Message> GetAll();
    }
}