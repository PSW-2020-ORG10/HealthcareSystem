/***********************************************************************
 * Module:  EquipmentRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EquipmentRepository
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using System;
using System.Collections.Generic;

namespace Class_diagram.Repository
{
   public class EquipmentRepository : GenericFileRepository<Equipment>
   {
        public EquipmentRepository(string filePath) : base(filePath){ }

        public EquipmentRepository() : base()   { }

   }
}