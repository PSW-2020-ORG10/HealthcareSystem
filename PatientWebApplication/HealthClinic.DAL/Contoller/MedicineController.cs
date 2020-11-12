/***********************************************************************
 * Module:  MedicineController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.MedicineController
 ***********************************************************************/

using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Service;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Contoller
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