using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Adapters
{
    public class MessageAdapter
    {
        public static Message MessageDTOtoMessage(MessageDto dto)
        {
            return new Message(dto.Text, dto.DateStamp, dto.TimeStamp, false, dto.PharmacyName, dto.DateAction);
        }

        public MessageDto MessageToMessageDTO(Message message)
        {
            return new MessageDto(message.Text, message.DateStamp, message.TimeStamp, message.PharmacyName, message.DateAction);
        }
    }
}