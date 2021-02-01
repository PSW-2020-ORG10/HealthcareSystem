/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using System.Collections.Generic;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
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