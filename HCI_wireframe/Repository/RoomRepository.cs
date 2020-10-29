/***********************************************************************
 * Module:  RoomRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RoomRepository
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using System;

namespace Class_diagram.Repository
{
   public class RoomRepository : GenericFileRepository<Room>
   {
        public RoomRepository(string filePath) : base(filePath)  { }

        public RoomRepository() : base()  { }

    }
}