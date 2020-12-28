using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Adapters
{
    public class MedicineForTenderingAdapter
    {
        public static MedicineForTendering MedicineForTenderingDtoToMedicineForTendering(MedicineForTenderingDto dto)
        {
            return new MedicineForTendering(dto.Name,dto.Quantity,dto.TenderId);
        }

        public MedicineForTenderingDto MedicineForebderingToMedicineForTenderingDto(MedicineForTendering medicine)
        {
            return new MedicineForTenderingDto(medicine.Name, medicine.Quantity,medicine.TenderId);
        }

    }
}
