using HealthClinic.CL.Model.ActionsAndBenefits;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public interface IMessageRepository
    {
        Message Create(Message message);

        List<Message> GetAll();
    }
}
