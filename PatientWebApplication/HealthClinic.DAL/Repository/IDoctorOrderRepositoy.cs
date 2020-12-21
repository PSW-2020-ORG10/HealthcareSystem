using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public interface IDoctorOrderRepositoy
    {  
        DoctorsOrder Add(DoctorsOrder order);
        List<DoctorsOrder> GetAll();
    }
}
