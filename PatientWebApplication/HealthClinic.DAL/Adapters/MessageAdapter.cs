using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.ActionsAndBenefits;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class MessageAdapter
    {
        public static Message MessageDTOtoMessage(MessageDTO dto)
        {
            return new Message(dto.Text, dto.Timestamp, false, dto.PharmacyName);
        }
       
        public MessageDTO MessageToMessageDTO(Message message)
        {
            return new MessageDTO(message.Text, message.Timestamp, message.PharmacyName);
        }
    }
}
