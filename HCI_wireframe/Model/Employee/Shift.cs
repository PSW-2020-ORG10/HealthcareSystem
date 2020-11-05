/***********************************************************************
 * Module:  Shift.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Shift
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;

namespace Class_diagram.Model.Employee
{
   public class Shift : Entity
    {
        public String startTime { get; set; }
        public String endTime { get; set; }
        public Shift()
        {

        }
        public Shift(String start, String end)
        {
            this.startTime = start;
            this.endTime = end;
        }

        public Shift(int id,String start, String end) : base(id)
        {
            this.startTime = start;
            this.endTime = end;
        }




    }
}