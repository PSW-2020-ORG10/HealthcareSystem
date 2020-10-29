/***********************************************************************
 * Module:  MedicineRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.MedicineRepository
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using System;
using System.Collections.Generic;

namespace Class_diagram.Repository
{
   public class MedicineRepository : GenericFileRepository<Medicine>
   {
        public MedicineRepository(string filePath) : base(filePath)  { }

        public MedicineRepository() : base() { }

   }
}