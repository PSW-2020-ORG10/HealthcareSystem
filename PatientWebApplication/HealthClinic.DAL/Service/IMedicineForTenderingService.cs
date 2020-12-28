using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Service
{
    public interface IMedicineForTenderingService
    {
        MedicineForTendering Create(MedicineForTenderingDto dto);

        List<MedicineForTendering> GetAll();
    }
}
