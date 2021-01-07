using MedicineReportApi.DbContextModel;
using MedicineReportApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MedicineReportApi.Repository
{
    public class RegistrationInPharmacyRepository : IRegistrationInPharmacyRepository
    {
        private MyDbContext DbContext;

        public RegistrationInPharmacyRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
 
        public List<RegistrationInPharmacy> GetAll()
        {
            return DbContext.Registrations.ToList();
        }
    }
}
