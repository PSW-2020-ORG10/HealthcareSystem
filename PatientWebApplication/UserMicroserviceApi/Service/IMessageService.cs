using System.Collections.Generic;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Service
{
    interface IMessageService
    {
        Message Create(MessageDto dto);

        List<Message> GetAll();
    }
}