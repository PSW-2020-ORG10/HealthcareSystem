using MedicineReportApi.DbContextModel;
using MedicineReportApi.Model;
using MedicineReportApi.Repository;
using System.Collections.Generic;

namespace MedicineReportApi.Service
{
    public class RegistrationInPharmacyService
    {
        public RegistrationInPharmacyRepository RegistrationInPharmacyRepository { get; }
        public RegistrationInPharmacyService() { }

        public RegistrationInPharmacyService(MyDbContext context)
        {
            RegistrationInPharmacyRepository = new RegistrationInPharmacyRepository(context);
        }
      
        public List<RegistrationInPharmacy> GetAll()
        {
            return RegistrationInPharmacyRepository.GetAll();
        }
    }
}
