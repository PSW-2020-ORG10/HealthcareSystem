using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.ActionsAndBenefits;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    interface IMessageService
    {
        Message Create(MessageDto dto);

        List<Message> GetAll();
    }
}