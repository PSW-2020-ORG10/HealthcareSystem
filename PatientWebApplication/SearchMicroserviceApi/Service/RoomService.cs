/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using SearchMicroserviceApi.Model;
using SearchMicroserviceApi.Repository;
using System;
using System.Collections.Generic;

namespace SearchMicroserviceApi.Service
{
    public class RoomService : IService<Room>
    {
        public RoomRepository roomRepository;
        public MedicineRepository medicineRepository;
        public EquipmentRepository equipmentRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository();
            medicineRepository = new MedicineRepository();
            equipmentRepository = new EquipmentRepository();
        }


        public bool isNameValid(string name)
        {
            foreach (Room room in GetAll())
            {
                if (room.TypeOfRoom.ToLower().Equals(name.ToLower())) return false;
            }
            return true;
        }

        public void New(Room room)
        {
            roomRepository.New(room);
        }

        public void Update(Room room)
        {
            roomRepository.Update(room);
        }

        public void Remove(Room room)
        {
            removeRoomFromAllMedicines(room);

            removeRoomFromAllEquipments(room);

            roomRepository.Delete(room.Id);
        }


        private bool isMedicineInRoom(Medicine medicine, Room room)
        {
            foreach (ModelRoom modelRoom in medicine.Room)
            {
                if (modelRoom.Data.Equals(room.TypeOfRoom))
                {
                    return true;
                }
            }

            return false;

        }

        private void removeRoomFromMedicine(Medicine medicine, Room room)
        {
            foreach (ModelRoom modelRoom in medicine.Room)
            {
                if (modelRoom.Data.Equals(room.TypeOfRoom) && isMedicineInRoom(medicine, room))
                {
                    medicine.Room.Remove(modelRoom);
                    medicineRepository.Update(medicine);
                }
            }
        }

        public void removeRoomFromAllMedicines(Room room)
        {
            List<Medicine> listOfMedicines = new List<Medicine>();
            foreach (Medicine medicine in medicineRepository.GetAll())
            {
                removeRoomFromMedicine(medicine, room);
            }
        }



        private bool isEquipmentInRoom(Equipment equipment, Room room)
        {
            foreach (ModelRoom modelRoom in equipment.Room)
            {
                if (modelRoom.Data.Equals(room.TypeOfRoom))
                {
                    return true;
                }
            }

            return false;
        }

        private void removeRoomFromEquipment(Equipment equipment, Room room)
        {
            foreach (ModelRoom modelRoom in equipment.Room)
            {
                if (modelRoom.Data.Equals(room.TypeOfRoom) && isEquipmentInRoom(equipment, room))
                {
                    equipment.Room.Remove(modelRoom);
                    equipmentRepository.Update(equipment);
                }
            }
        }

        public void removeRoomFromAllEquipments(Room room)
        {
            foreach (Equipment equipment in equipmentRepository.GetAll())
            {
                removeRoomFromEquipment(equipment, room);
            }
        }

        public List<Room> GetAll()
        {
            return roomRepository.GetAll();
        }

        public Room GetByid(int id)
        {
            throw new NotImplementedException();
        }
    }
}