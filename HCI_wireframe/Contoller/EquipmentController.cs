/***********************************************************************
 * Module:  EquipmentController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.EquipmentController
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using System;
using System.Collections.Generic;

namespace Class_diagram.Contoller
{
   public class EquipmentController : IController<Equipment>
    {
        public EquipmentService equipmentService;
        public EquipmentController()
        {
            equipmentService = new EquipmentService();
        }

        public Boolean isNameValid(String name)
        {
            return equipmentService.isNameValid(name);
        }

        public List<Equipment> GetAll()
        {
            return equipmentService.GetAll();
          
        }

        public void New(Equipment equipment)
        {
            equipmentService.New(equipment);
        }
      
         public void Update(Equipment equipment)
         {
            equipmentService.Update(equipment);
         }
      
        public void Remove(Equipment equipment)
        {
            equipmentService.Remove(equipment);
        }

        public Equipment GetByid(int id)
        {
            return equipmentService.GetByid(id);
        }
    }
}