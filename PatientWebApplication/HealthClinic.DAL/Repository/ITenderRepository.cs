using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
    public interface ITenderRepository
    {
        Tender Create(Tender tender);
        List<Tender> GetAll();
    }
}
