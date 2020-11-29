using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Repository
{
    interface IMedicineForOrderingRepository
    {
        MedicineForOrdering Create(MedicineForOrdering medicine);
        List<MedicineForOrdering> GetAll();
    }
}
