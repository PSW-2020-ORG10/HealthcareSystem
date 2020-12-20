using HealthClinic.CL.Model.ActionsAndBenefits;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IMessageRepository
    {
        Message Create(Message message);

        List<Message> GetAll();
    }
}