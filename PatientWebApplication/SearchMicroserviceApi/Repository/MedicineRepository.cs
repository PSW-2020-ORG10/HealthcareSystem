/***********************************************************************
 * Module:  MedicineRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.MedicineRepository
 ***********************************************************************/

using System.Collections.Generic;
using System.Linq;
using SearchMicroserviceApi.DbContextModel;
using SearchMicroserviceApi.Model;

namespace SearchMicroserviceApi.Repository
{
    public class MedicineRepository : GenericFileRepository<Medicine>
    {
        private MyDbContext DbContext;
        public MedicineRepository(string filePath) : base(filePath) { }

        public MedicineRepository() : base() { }

        public MedicineRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public List<Medicine> GetAll()
        {
            return DbContext.Medicines.ToList();
        }
    }
}