/***********************************************************************
 * Module:  Medicine.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Manager.Medicine
 ***********************************************************************/


using System.Collections.Generic;


namespace SearchMicroserviceApi.Model
{
    public class Medicine : Equipment
    {
        public string Description { get; set; }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room) : base(id, name, quantity, room)
        {
            Description = description;
            Name = name;
            Quantity = quantity;
        }

        public Medicine() : base() { }
    }
}