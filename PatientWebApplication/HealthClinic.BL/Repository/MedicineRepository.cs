/***********************************************************************
 * Module:  MedicineRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.MedicineRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Hospital;
using System;
using System.Collections.Generic;

namespace HealthClinic.BL.Repository
{
    public class MedicineRepository : GenericFileRepository<Medicine>
   {
        public MedicineRepository(string filePath) : base(filePath)  { }

        public MedicineRepository() : base() { }

   }
}