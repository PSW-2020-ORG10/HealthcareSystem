/***********************************************************************
 * Module:  RoomController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.RoomController
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using System;
using System.Collections.Generic;

namespace Class_diagram.Contoller
{
   public class RoomController : IController<Room>
    {
        public RoomService roomService;

        public RoomController()
        {
            roomService = new RoomService();
        }

        public Boolean isNameValid(String name)
        {
            return roomService.isNameValid(name);
        }

        public void New(Room room)
        { 
            roomService.New(room);
        }
      
        public void Update(Room room)
        {
            roomService.Update(room);
        }

        public List<Room> GetAll()
        {
           return roomService.GetAll();
        }

        public void Remove(Room room)
        {
            roomService.Remove(room);
        }

        public Room GetByid(int id)
        {
            return roomService.GetByid(id);
        }
    }
}