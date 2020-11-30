using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Adapters
{
    public class DoctorsOrderAdapter
    {
        public static DoctorsOrder DoctorsOrderDtoToDoctorsOrder(DoctorsOrderDto dto)
        {
            return new DoctorsOrder(dto.IsUrgent, dto.DateStart, dto.DateEnd, dto.IsOrdered, dto.IsFinished);
        }

        public DoctorsOrderDto DoctorsOrderToDoctorsOrderDTO(DoctorsOrder order)
        {
            return new DoctorsOrderDto(order.IsUrgent, order.DateStart, order.DateEnd, order.IsOrdered,order.IsFinished);
        }

    }
}
