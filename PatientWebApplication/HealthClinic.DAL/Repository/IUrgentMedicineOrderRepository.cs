using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
    public interface IUrgentMedicineOrderRepository
    {
        UrgentMedicineOrder Create(UrgentMedicineOrder order);
        List<UrgentMedicineOrder> GetAll();
    }
}
