using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class DoctorsOrderAdapter
    {
        public static DoctorsOrder DoctorsOrderDtoToDoctorsOrder(DoctorsOrderDto dto)
        {
            return new DoctorsOrder(1,dto.isUrgent, dto.dateStart,dto.dateEnd,dto.isOrdered,dto.isFinished);
        }

        public DoctorsOrderDto DoctorsOrderToDoctorsOrderDTO(DoctorsOrder order)
        {
            return new DoctorsOrderDto(order.isUrgent, order.dateStart, order.dateEnd, order.isOrdered,order.isFinished);
        }

    }
}
