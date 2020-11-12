/***********************************************************************
 * Module:  MedicineRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.MedicineRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    public class MedicineRepository : GenericFileRepository<Medicine>
   {
        public MedicineRepository(string filePath) : base(filePath)  { }

        public MedicineRepository() : base() { }

   }
}