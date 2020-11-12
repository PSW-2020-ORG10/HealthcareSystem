/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;

namespace HealthClinic.CL.Repository
{
    public class DoctorRepository : GenericFileRepository<DoctorUser>
   {
        public DoctorRepository() : base() { }

        public DoctorRepository(string filePath) : base(filePath) { }

   }
}