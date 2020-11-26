using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public interface IDoctorOrderService
    {
        DoctorsOrder Create(DoctorsOrderDto orderDto);
        List<DoctorsOrder> GetAll();
    }
}
