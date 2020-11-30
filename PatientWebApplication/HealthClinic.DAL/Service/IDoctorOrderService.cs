using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;


namespace HealthClinic.CL.Service
{
    public interface IDoctorOrderService
    {
        DoctorsOrder Create(DoctorsOrderDto orderDto);
        List<DoctorsOrder> GetAll();
    }
}
