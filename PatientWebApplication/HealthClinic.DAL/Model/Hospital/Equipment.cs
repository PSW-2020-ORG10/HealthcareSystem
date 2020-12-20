/***********************************************************************
 * Module:  Equipment.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Equipment
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Hospital
{
    public class Equipment : Entity
    {
        public virtual List<ModelRoom> room { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public Equipment()
        {
        }
        public Equipment(int id, string name, int quantity) : base(id)
        {

            this.name = name;
            this.quantity = quantity;
        }
        public Equipment(int id, string name, int quantity, List<ModelRoom> room) : base(id)
        {

            this.name = name;
            this.quantity = quantity;
            this.room = room;
        }
        public Equipment(string name, int quantity) : base()
        {
            this.name = name;
            this.quantity = quantity;
        }


    }
}