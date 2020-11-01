/***********************************************************************
 * Module:  MedicineController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.MedicineController
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using Class_diagram.Model.Hospital;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;

namespace Class_diagram.Contoller
{
   public class MedicineController : IController<Medicine>
    {
        public MedicineService medicineService;

        public MedicineController()
        {
            medicineService = new MedicineService();
        }

        public Boolean isNameValid(String name)
        {
            return medicineService.isNameValid(name);
        }

        public void New(Medicine medicine)
        {
            medicineService.New(medicine);
        }

        public void Update(Medicine medicine)
        {
            medicineService.Update(medicine);
        }
      
        public void Remove(Medicine medicine)
        { 
            medicineService.Remove(medicine);
        }
      
         public List<Medicine> GetAll()
         {
           return medicineService.GetAll();

          }

        public Medicine GetByid(int id)
        {
           return medicineService.GetByid(id);
        }
    }
}