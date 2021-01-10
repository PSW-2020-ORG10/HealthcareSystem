/***********************************************************************
 * Module:  Equipment.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Equipment
 ***********************************************************************/

using System.Collections.Generic;

namespace SearchMicroserviceApi.Model
{
    public class Equipment : Entity
    {
        public virtual List<ModelRoom> Room { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Equipment()
        {
        }
        public Equipment(int id, string name, int quantity) : base(id)
        {

            Name = name;
            Quantity = quantity;
        }
        public Equipment(int id, string name, int quantity, List<ModelRoom> room) : base(id)
        {

            Name = name;
            Quantity = quantity;
            Room = room;
        }
        public Equipment(string name, int quantity) : base()
        {
            Name = name;
            Quantity = quantity;
        }
    }
}