/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    public class RoomRepository : GenericFileRepository<Room>
   {
      private readonly MyDbContext dbContext;
      public RoomRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }

      public RoomRepository(string filePath) : base(filePath)  { }

        public RoomRepository() : base()  { }

    }
}