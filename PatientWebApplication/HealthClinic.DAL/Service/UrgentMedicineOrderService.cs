using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;

namespace HealthClinic.CL.Service
{
    class UrgentMedicineOrderService : IUrgentMedicineOrderService
    {
        public UrgentMedicineOrderRepository UrgentMedicineOrderRepository { get; }
        public UrgentMedicineOrderService() { }

        public UrgentMedicineOrderService(MyDbContext context)
        {
            UrgentMedicineOrderRepository = new UrgentMedicineOrderRepository(context);
        }

        public UrgentMedicineOrder Create(UrgentMedicineOrderDto dto)
        {
            return UrgentMedicineOrderRepository.Create(UrgentMedicineOrderAdapter.UrgentMedicineOrderDtoUrgentMedicineOrder(dto));
        }

        public List<UrgentMedicineOrder> GetAll()
        {
            return UrgentMedicineOrderRepository.GetAll();
        }
     
    }
}
