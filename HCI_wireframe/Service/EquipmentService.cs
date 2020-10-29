/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Class_diagram.Service
{
   public class EquipmentService : bingPath, IService<Equipment>
    {
        public RoomRepository roomRepository;
        public EquipmentRepository equipmentRepository;
        String path = bingPathToAppDir(@"JsonFiles\equipment.json");
        String path2 = bingPathToAppDir(@"JsonFiles\room.json");

        public EquipmentService()
        {
            equipmentRepository = new EquipmentRepository(path);
            roomRepository = new RoomRepository(path2);
        }

        public Boolean isNameValid(String name)
        {
            List<Equipment> listOfEquipments = GetAll();

            foreach (Equipment equipment in listOfEquipments)
            {
                if (equipment.Name.ToLower().Equals(name.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }

        public void New(Equipment equipment)
        {
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();
            
            foreach (Room room in listOfRooms)
            {
                if (room.TypeOfRoom.Equals("Magacin"))
                {
                    equipment.room.Add(room.TypeOfRoom);
                    room.equipment.Add(equipment.Name);
                    roomRepository.Update(room);
                }
            }
            equipmentRepository.New(equipment);
        }
      
      public void Update(Equipment equipment)
      {
            equipmentRepository.Update(equipment);
      }
      
      public void Remove(Equipment equipment)
      {
            List<Equipment> listOfEquipments = equipmentRepository.GetAll();

            foreach (Equipment equipmentObject in listOfEquipments)
            {
                if (equipmentObject.ID == equipment.ID)
                {
                    equipmentRepository.Delete(equipment.ID);

                }
            }
            removeEquipmentFromRoom(equipment);
        }

        public void removeEquipmentFromRoom(Equipment equipment)
        {
           
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();

            foreach (Room room in listOfRooms)
            {
                if (room.equipment.Contains(equipment.Name))
                {
                    room.equipment.Remove(equipment.Name);
                    roomRepository.Update(room);
                }
            }

        }
      
        public List<Equipment> GetAll()
        {
           return equipmentRepository.GetAll();

        }

        public Equipment GetByID(int ID)
        {
            return equipmentRepository.GetByID(ID);
        }
    }
}