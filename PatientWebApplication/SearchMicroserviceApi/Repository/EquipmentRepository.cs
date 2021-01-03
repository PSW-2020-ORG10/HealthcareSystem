/***********************************************************************
 * Module:  EquipmentRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EquipmentRepository
 ***********************************************************************/

using SearchMicroserviceApi.Model;

namespace SearchMicroserviceApi.Repository
{
    public class EquipmentRepository : GenericFileRepository<Equipment>
    {
        public EquipmentRepository(string filePath) : base(filePath) { }

        public EquipmentRepository() : base() { }

    }
}