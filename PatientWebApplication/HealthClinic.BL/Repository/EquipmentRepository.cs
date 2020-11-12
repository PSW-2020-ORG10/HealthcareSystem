/***********************************************************************
 * Module:  EquipmentRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EquipmentRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Hospital;
using System;
using System.Collections.Generic;

namespace HealthClinic.BL.Repository
{
    public class EquipmentRepository : GenericFileRepository<Equipment>
   {
        public EquipmentRepository(string filePath) : base(filePath){ }

        public EquipmentRepository() : base()   { }

   }
}