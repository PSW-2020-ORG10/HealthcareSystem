/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Repository;
using HCI_wireframe.Service;
using HealthClinic.BL.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using WpfApp2;

namespace Class_diagram.Service
{
    public class EquipmentService : BingPath, IService<Equipment>
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
                if (equipment.name.ToLower().Equals(name.ToLower())) return false;
            }

            return true;
        }


        private void addEquipmentIfRoomIsStorage(Equipment equipment, Room room)
        {
            if (room.typeOfRoom.Equals("Magacin"))
            {
                equipment.room.Add(new ModelRoom(room.typeOfRoom));
                room.equipment.Add(new ModelEquipment(equipment.name));
                roomRepository.Update(room);
            }
        }

        private void addEquipmentInStorages(Equipment equipment)
        {
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();

            foreach (Room room in listOfRooms)
            {
                addEquipmentIfRoomIsStorage(equipment, room);
            }
        }

        public void New(Equipment equipment)
        {
            addEquipmentInStorages(equipment);
            equipmentRepository.New(equipment);
        }

        public void Update(Equipment equipment)
        {
            equipmentRepository.Update(equipment);
        }

        private void deleteIfEquipmentsEqual(Equipment firstEquipment, Equipment secondEquipment)
        {
            if (firstEquipment.id == secondEquipment.id)
            {
                equipmentRepository.Delete(firstEquipment.id);

            }

        }
        public void Remove(Equipment equipment)
        {
            List<Equipment> listOfEquipments = equipmentRepository.GetAll();

            foreach (Equipment equipmentIt in listOfEquipments)
            {
                deleteIfEquipmentsEqual(equipmentIt, equipment);
            }
            removeEquipmentFromAllRooms(equipment);
        }

        private void removeEquipmentFromSpecificRoom(Equipment equipment, Room room)
        {
            foreach (ModelEquipment modelEquipment in room.equipment)
            {
                if (modelEquipment.Data.Equals(equipment.name))
                {
                    room.equipment.Remove(modelEquipment);
                    roomRepository.Update(room);
                }
            }
        }



        public void removeEquipmentFromAllRooms(Equipment equipment)
        {
           
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();

            foreach (Room room in listOfRooms)
            {
                removeEquipmentFromSpecificRoom(equipment,room);
            }

        }
      
        public List<Equipment> GetAll()
        {
           return equipmentRepository.GetAll();

        }

        public Equipment GetByid(int id)
        {
            return equipmentRepository.GetByid(id);
        }
    }
}