using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Service
{
    public interface IUrgentMedicineOrderService
    {
        UrgentMedicineOrder Create(UrgentMedicineOrderDto dto);

        List<UrgentMedicineOrder> GetAll();
    }
}
