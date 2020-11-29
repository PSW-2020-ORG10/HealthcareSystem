using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class MessageService:IMessageService
    {
        private IMessageRepository MessageRepository { get; set; }
        public MessageService()
        {
            MessageRepository = new MessageRepository();
        }

        public MessageService(IMessageRepository messageRepository)
        {
            MessageRepository = messageRepository;
        }

        public Message Create(MessageDTO dto)
        {
            Message message = MessageAdapter.MessageDTOtoMessage(dto);
            return MessageRepository.Create(message);
        }

        public List<Message> GetAll()
        {
            return MessageRepository.GetAll();
        }
    }
}
