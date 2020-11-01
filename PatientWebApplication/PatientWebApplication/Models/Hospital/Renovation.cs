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
   
      public String StartDate{ get; set; }
      public String EndDate{ get; set; }

      public Renovation(int id, String r, String start, String end) : base(id)
        {
            this.room = r;
            this.StartDate = start;
            this.EndDate = end;
        }

    public Renovation() : base()
        {

        }

    }
}