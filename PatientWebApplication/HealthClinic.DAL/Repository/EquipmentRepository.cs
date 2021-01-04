/***********************************************************************
 * Module:  EquipmentRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EquipmentRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    public class EquipmentRepository : GenericFileRepository<Equipment>
   {
      private readonly MyDbContext dbContext;
      public EquipmentRepository(MyDbContext context)
      {
         this.dbContext = context;
      }

      public EquipmentRepository(string filePath) : base(filePath){ }

        public EquipmentRepository() : base()   { }

   }
}