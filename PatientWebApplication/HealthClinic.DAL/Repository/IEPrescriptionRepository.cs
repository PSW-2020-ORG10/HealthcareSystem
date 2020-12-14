using HealthClinic.CL.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public interface IEPrescriptionRepository
    {
        EPrescription Create(EPrescription prescription);
        List<EPrescription> GetAll();
    }
}
