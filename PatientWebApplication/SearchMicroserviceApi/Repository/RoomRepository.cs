/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using SearchMicroserviceApi.DbContextModel;
using SearchMicroserviceApi.Model;

namespace SearchMicroserviceApi.Repository
{
    public class RoomRepository : GenericFileRepository<Room>
    {
        private readonly MyDbContext dbContext;
        public RoomRepository(MyDbContext context)
        {
            this.dbContext = context;
        }

        public RoomRepository(string filePath) : base(filePath) { }

        public RoomRepository() : base() { }

    }
}