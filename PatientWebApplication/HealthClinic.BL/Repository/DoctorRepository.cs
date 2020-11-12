/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Doctor;

namespace HealthClinic.BL.Repository
{
    public class DoctorRepository : GenericFileRepository<DoctorUser>
   {
        public DoctorRepository() : base() { }

        public DoctorRepository(string filePath) : base(filePath) { }

   }
}