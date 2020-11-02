/***********************************************************************
 * Module:  Shift.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Shift
 ***********************************************************************/

using System;

namespace Class_diagram.Model.Employee
{
   public class Shift
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

      
      

    }
}