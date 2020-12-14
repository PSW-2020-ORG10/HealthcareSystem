using System;
using System.Collections.Generic;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
    public interface IMedicineDescriptionRepository
    {
        MedicineDescription Create(MedicineDescription medicineDescription);
        List<MedicineDescription> GetAll();
    }
}
