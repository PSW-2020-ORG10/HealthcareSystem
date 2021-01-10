/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using SearchMicroserviceApi.DbContextModel;
using SearchMicroserviceApi.Model;
using SearchMicroserviceApi.Repository;
using System.Collections.Generic;

namespace SearchMicroserviceApi.Service
{
    public class MedicineService : IService<Medicine>
    {
        public MedicineRepository medicineRepository;

        public MedicineService()
        {          
        }
        public MedicineService(MyDbContext context)
        {
            medicineRepository = new MedicineRepository(context);
        }
        public void New(Medicine medicine)
        {
            medicineRepository.New(medicine);
        }

        public void Update(Medicine medicine)
        {
            medicineRepository.Update(medicine);
        }

        private void deleteIfMedicinesAreEqual(Medicine firstMedicine, Medicine secondMedicine)
        {
            if (firstMedicine.Id == secondMedicine.Id)
            {
                medicineRepository.Delete(firstMedicine.Id);

            }
        }

        public void Remove(Medicine medicine)
        {
            foreach (Medicine medicineObject in medicineRepository.GetAll())
            {
                deleteIfMedicinesAreEqual(medicineObject, medicine);
            }
            removeMedicineFromAllRoom(medicine);
        }
        private void removeMedicineFromSpecificRoom(Room room, Medicine medicine, RoomService roomService)
        {
            foreach (ModelMedicine modelMedicine in room.Medicine)
            {
                if (modelMedicine.Data.Equals(medicine.Name))
                {
                    room.Medicine.Remove(modelMedicine);
                    roomService.Update(room);
                }
            }

        }
        public void removeMedicineFromAllRoom(Medicine medicine)
        {
            RoomService roomService = new RoomService();
            foreach (Room room in roomService.GetAll())
            {
                removeMedicineFromSpecificRoom(room, medicine, roomService);
            }

        }

        private bool isNamesOfMedicineEqual(Medicine medicine, string nameOfSecondMedicine)
        {
            return (medicine.Name.ToLower().Equals(nameOfSecondMedicine.ToLower())) ? true : false;
        }

        public bool isNameValid(string name)
        {
            foreach (Medicine medicine in GetAll())
            {
                if (isNamesOfMedicineEqual(medicine, name))
                {
                    return false;
                }
            }
            return true;
        }

        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();

        }

        public Medicine GetByid(int id)
        {
            return medicineRepository.GetByid(id);
        }
    }
}