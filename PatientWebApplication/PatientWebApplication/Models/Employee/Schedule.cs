/***********************************************************************
 * Module:  Schedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Schedule
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;

namespace Class_diagram.Model.Employee
{
    public class Schedule : Entity
    {
        public String employeeFirst { get; set; }
        public String employeeLast { get; set; }
        public String employeeID { get; set; }

        public String Date { get; set; }
        public Boolean OnDuty { get; set; }

        public Shift shift { get; set; }
       
        public String soba { get; set; }


        public Schedule(int id, String employeeID, String dateOne, Boolean duty, String emplFirst, String emplLast, Shift shifts , String s) : base(id)
        {
            this.employeeID = employeeID;
            this.Date = dateOne;
            this.OnDuty = duty;
            this.employeeFirst= emplFirst;
            this.employeeLast = emplLast;
            this.shift = shifts;
            this.soba = s;
        }

        public Schedule() : base()
        {
        
        }

    }
}