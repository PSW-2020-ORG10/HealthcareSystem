/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;
using System.Collections.Generic;

namespace UserMicroservice.Repository
{
    public interface IDoctorRepository
    {
        void Delete(int id);
        List<DoctorUser> GetAll();
        DoctorUser GetByid(int id);
        void New(DoctorUser doctor);
        void Update(DoctorUser doctor);
    }
}