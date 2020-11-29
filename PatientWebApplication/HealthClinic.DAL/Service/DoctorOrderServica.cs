using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Adapters;
namespace HealthClinic.CL.Service
{
    public class DoctorOrderServica
    {
        public DoctorOrderRepository DoctorOrderRepository { get; }
        public object DoctorOrderAdapter { get; private set; }

        public DoctorOrderServica() { }

        public DoctorOrderServica(MyDbContext context)
        {
            DoctorOrderRepository = new DoctorOrderRepository(context);
        }
        public List<DoctorsOrder> GetAll()
        {
            return DoctorOrderRepository.GetAll();
        }
        public DoctorsOrder Create(DoctorsOrderDto dto)
        {
            DoctorsOrder order = DoctorsOrderAdapter.DoctorsOrderDtoToDoctorsOrder(dto);
            return DoctorOrderRepository.Add(order);
        }
    }
}
