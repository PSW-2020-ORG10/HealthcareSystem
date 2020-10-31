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
        public Shift(String start, String end)
        {
            this.StartTime = start;
            this.EndTime = end;
        }

        public Shift()
        {
           
        }
        public String StartTime { get; set; }
        public String EndTime { get; set; }

    }
}