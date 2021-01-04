using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    class RequestMedicineRepository : GenericFileRepository<Medicine>
    {
      private readonly MyDbContext dbContext;
      public RequestMedicineRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }

      public RequestMedicineRepository(string filePath) : base(filePath) { }

        public RequestMedicineRepository() :  base() { }
       
    }
}