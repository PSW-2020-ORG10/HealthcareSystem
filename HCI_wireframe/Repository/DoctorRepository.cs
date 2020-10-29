/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using HCI_wireframe.Model.Doctor;
using System;

namespace Class_diagram.Repository
{
   public class DoctorRepository : GenericFileRepository<DoctorUser>
   {
        public DoctorRepository() : base() { }

        public DoctorRepository(string filePath) : base(filePath) { }

   }
}