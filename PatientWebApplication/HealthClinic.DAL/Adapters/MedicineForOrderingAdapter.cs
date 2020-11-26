using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class MedicineForOrderingAdapter
    {
        public static MedicineForOrdering MedicineOrderDtoToMedicineOrder(MedicineForOrderingDto dto)
        {
            return new MedicineForOrdering(2, dto.name, dto.quantity, dto.description, dto.orderId);
        }

        public MedicineForOrderingDto MedicineOrderToMedicineOrderDto(MedicineForOrdering medicine)
        {
            return new MedicineForOrderingDto(medicine.name, medicine.quantity, medicine.description, medicine.orderId);
        }

    }
}
