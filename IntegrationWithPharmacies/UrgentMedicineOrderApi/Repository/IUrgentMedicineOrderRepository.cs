using System.Collections.Generic;
using UrgentMedicineOrderApi.Model;

namespace UrgentMedicineOrderApi.Repository
{
    public interface IUrgentMedicineOrderRepository
    {
        UrgentMedicineOrder Create(UrgentMedicineOrder order);
        List<UrgentMedicineOrder> GetAll();
    }
}
