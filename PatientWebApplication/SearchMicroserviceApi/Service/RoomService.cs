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


        public bool IsNameValid(string name)
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
            RemoveRoomFromAllMedicines(room);

            RemoveRoomFromAllEquipments(room);

            roomRepository.Delete(room.Id);
        }


        private bool IsMedicineInRoom(Medicine medicine, Room room)
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

        private void RemoveRoomFromMedicine(Medicine medicine, Room room)
        {
            foreach (ModelRoom modelRoom in medicine.Room)
            {
                if (modelRoom.Data.Equals(room.TypeOfRoom) && IsMedicineInRoom(medicine, room))
                {
                    medicine.Room.Remove(modelRoom);
                    medicineRepository.Update(medicine);
                }
            }
        }

        public void RemoveRoomFromAllMedicines(Room room)
        {
            List<Medicine> listOfMedicines = new List<Medicine>();
            foreach (Medicine medicine in medicineRepository.GetAll())
            {
                RemoveRoomFromMedicine(medicine, room);
            }
        }



        private bool IsEquipmentInRoom(Equipment equipment, Room room)
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

        private void RemoveRoomFromEquipment(Equipment equipment, Room room)
        {
            foreach (ModelRoom modelRoom in equipment.Room)
            {
                if (modelRoom.Data.Equals(room.TypeOfRoom) && IsEquipmentInRoom(equipment, room))
                {
                    equipment.Room.Remove(modelRoom);
                    equipmentRepository.Update(equipment);
                }
            }
        }

        public void RemoveRoomFromAllEquipments(Room room)
        {
            foreach (Equipment equipment in equipmentRepository.GetAll())
            {
                RemoveRoomFromEquipment(equipment, room);
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