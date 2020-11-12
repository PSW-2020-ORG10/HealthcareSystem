using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    class RequestMedicineRepository : GenericFileRepository<Medicine>
    {
        public RequestMedicineRepository(string filePath) : base(filePath) { }

        public RequestMedicineRepository() :  base() { }
       
    }
}