using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Service
{
    public interface ITenderService
    {
        Tender Create(TenderDto dto);

        List<Tender> GetAll();
    }
}
