/***********************************************************************
 * Module:  EquipmentRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EquipmentRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    public class EquipmentRepository : GenericFileRepository<Equipment>
   {
        public EquipmentRepository(string filePath) : base(filePath){ }

        public EquipmentRepository() : base()   { }

   }
}