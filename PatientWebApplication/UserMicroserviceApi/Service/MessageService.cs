using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Repository;
using System.Collections.Generic;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public class MessageService : IMessageService
    {

        private IMessageRepository MessageRepository { get; set; }

        public MessageService()
        {
            MessageRepository = new MessageRepository();
        }
        public MessageService(MyDbContext dbContext)
        {
            MessageRepository = new MessageRepository(dbContext);
        }

        public MessageService(IMessageRepository messageRepository)
        {
            MessageRepository = messageRepository;
        }

        public Message Create(MessageDto dto)
        {
            return MessageRepository.Create(MessageAdapter.MessageDTOtoMessage(dto));
        }

        public List<Message> GetAll()
        {
            return MessageRepository.GetAll();
        }
    }
}