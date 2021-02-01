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

        private void DeleteIfMedicinesAreEqual(Medicine firstMedicine, Medicine secondMedicine)
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
                DeleteIfMedicinesAreEqual(medicineObject, medicine);
            }
            RemoveMedicineFromAllRoom(medicine);
        }
        private void RemoveMedicineFromSpecificRoom(Room room, Medicine medicine, RoomService roomService)
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
        public void RemoveMedicineFromAllRoom(Medicine medicine)
        {
            RoomService roomService = new RoomService();
            foreach (Room room in roomService.GetAll())
            {
                RemoveMedicineFromSpecificRoom(room, medicine, roomService);
            }

        }

        private bool IsNamesOfMedicineEqual(Medicine medicine, string nameOfSecondMedicine)
        {
            return (medicine.Name.ToLower().Equals(nameOfSecondMedicine.ToLower())) ? true : false;
        }

        public bool IsNameValid(string name)
        {
            foreach (Medicine medicine in GetAll())
            {
                if (IsNamesOfMedicineEqual(medicine, name))
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