using System.Collections.Generic;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Adapters;
namespace HealthClinic.CL.Service
{
    public class DoctorOrderService
    {
        public DoctorOrderRepository DoctorOrderRepository { get; }
        public object DoctorOrderAdapter { get; private set; }

        public DoctorOrderService() { }

        public DoctorOrderService(MyDbContext context)
        {
            DoctorOrderRepository = new DoctorOrderRepository(context);
        }
        public List<DoctorsOrder> GetAll()
        {
            return DoctorOrderRepository.GetAll();
        }
        public DoctorsOrder Create(DoctorsOrderDto dto)
        {
            return DoctorOrderRepository.Add(DoctorsOrderAdapter.DoctorsOrderDtoToDoctorsOrder(dto));
        }
    }
}
