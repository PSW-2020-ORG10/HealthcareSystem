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
        public IDoctorOrderRepositoy IdoctorOrderRepository { get; }
        public object DoctorOrderAdapter { get; private set; }

        public DoctorOrderService() { }

        public DoctorOrderService(MyDbContext context)
        {
            DoctorOrderRepository = new DoctorOrderRepository(context);
        }
        public DoctorOrderService(IDoctorOrderRepositoy orderRepository)
        {
            IdoctorOrderRepository = orderRepository;
        }
        public List<DoctorsOrder> GetAll()
        {
            return DoctorOrderRepository.GetAll();
        }
        public DoctorsOrder Create(DoctorsOrderDto dto)
        {
            return DoctorOrderRepository.Add(DoctorsOrderAdapter.DoctorsOrderDtoToDoctorsOrder(dto));
        }
        public List<DoctorsOrder> GetAllForStub()
        {
            return IdoctorOrderRepository.GetAll();
        }
    }
}
