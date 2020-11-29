using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.ActionsAndBenefits;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    interface IMessageService
    {
        Message Create(MessageDTO dto);

        List<Message> GetAll();
    }
}
