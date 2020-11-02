/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Luna
 * Purpose: Definition of the Class Hospital.Renovation
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;

namespace Class_diagram.Model.Hospital
{
   public class Renovation : Entity
   {
      public String room { get; set; }
   
      public String startDate{ get; set; }
      public String endDate{ get; set; }

      public Renovation(int id, String room, String startDate, String endDate) : base(id)
        {
            this.room = room;
            this.startDate = startDate;
            this.endDate = endDate;
        }

    public Renovation() : base()
        {

        }

    }
}