using MedicineReportApi.Model;
using System.Collections.Generic;

namespace MedicineReportApi.Repository
{
    public interface IRegistrationInPharmacyRepository
    {
        List<RegistrationInPharmacy> GetAll();
    }
}
