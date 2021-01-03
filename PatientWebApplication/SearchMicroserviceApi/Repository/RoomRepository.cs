/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using SearchMicroserviceApi.Model;

namespace SearchMicroserviceApi.Repository
{
    public class RoomRepository : GenericFileRepository<Room>
    {
        public RoomRepository(string filePath) : base(filePath) { }

        public RoomRepository() : base() { }

    }
}