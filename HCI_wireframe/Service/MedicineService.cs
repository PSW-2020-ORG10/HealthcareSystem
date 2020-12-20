/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Model.Hospital;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Animation;

namespace Class_diagram.Service
{
    public class MedicineService : BingPath, IService<Medicine>
    {
        public MedicineRepository medicineRepository;
        String path = bingPathToAppDir(@"JsonFiles\medicine.json");

        public MedicineService()
        {
            medicineRepository = new MedicineRepository(path);
        }

        public void New(Medicine medicine)
        {
            medicineRepository.New(medicine);
        }

        public void Update(Medicine medicine)
        {
            medicineRepository.Update(medicine);
        }

        private void deleteIfMedicinesAreEqual(Medicine firstMedicine,Medicine secondMedicine)
        {
            if (firstMedicine.id == secondMedicine.id)
            {
                medicineRepository.Delete(firstMedicine.id);

            }
        }

        public void Remove(Medicine medicine)
        {
            List<Medicine> listOfMedicines = medicineRepository.GetAll();

            foreach (Medicine medicineObject in listOfMedicines)
            {
                deleteIfMedicinesAreEqual(medicineObject, medicine);
            }

            removeMedicineFromAllRoom(medicine);

        }
        private void removeMedicineFromSpecificRoom(Room room, Medicine medicine,RoomController roomController){
            foreach (ModelMedicine modelMedicine in room.medicine)
            {
                if (modelMedicine.Data.Equals(medicine.name))
                {
                    room.medicine.Remove(modelMedicine);
                    roomController.Update(room);
                }
            }

        }
        public void removeMedicineFromAllRoom(Medicine medicine)
        {
            RoomController roomController = new RoomController();
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomController.GetAll();

            foreach (Room room in listOfRooms)
            {
                removeMedicineFromSpecificRoom(room, medicine, roomController);
            }

        }

        private bool isNamesOfMedicineEqual(Medicine medicine,string nameOfSecondMedicine)
        {
            if (medicine.name.ToLower().Equals(nameOfSecondMedicine.ToLower())) return true;
            return false;
        }

        public Boolean isNameValid(String name)
        {
            List<Medicine> listOfMedicines = GetAll();

            foreach (Medicine medicine in listOfMedicines)
            {
                if (isNamesOfMedicineEqual(medicine,name))
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