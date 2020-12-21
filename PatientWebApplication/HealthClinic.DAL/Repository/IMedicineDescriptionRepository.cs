using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public interface IMedicineDescriptionRepository
    {
        MedicineDescription Create(MedicineDescription medicine);
        List<MedicineDescription> GetAll();
    }
}
