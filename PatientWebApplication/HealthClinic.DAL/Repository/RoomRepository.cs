/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    public class RoomRepository : GenericFileRepository<Room>
   {
        public RoomRepository(string filePath) : base(filePath)  { }

        public RoomRepository() : base()  { }

    }
}