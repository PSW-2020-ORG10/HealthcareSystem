/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Hospital;
using System;

namespace HealthClinic.BL.Repository
{
    public class RoomRepository : GenericFileRepository<Room>
   {
        public RoomRepository(string filePath) : base(filePath)  { }

        public RoomRepository() : base()  { }

    }
}