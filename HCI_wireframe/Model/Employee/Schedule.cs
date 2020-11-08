/***********************************************************************
 * Module:  Schedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Schedule
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Employee;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Class_diagram.Model.Employee
{
    public class Schedule : Entity
    {
        public String employeeFirst { get; set; }
        public String employeeLast { get; set; }
        public String employeeid { get; set; }

        public String date { get; set; }
        public Boolean isOnDuty { get; set; }

        public int shiftId { get; set; }
        public virtual Shift shift { get; set; }
       
        public String room { get; set; }
        public Schedule() : base() { }


        public Schedule(int id, String employeeid, String date, Boolean isOnDuty, String employeeFirst, String employeeLast, Shift shift, String room) : base(id)
        {
            this.employeeid = employeeid;
            this.date = date;
            this.isOnDuty = isOnDuty;
            this.employeeFirst= employeeFirst;
            this.employeeLast = employeeLast;
            this.shift = shift;
            this.room = room;
        }

        public Schedule(int id, String employeeid, String date, Boolean isOnDuty, String employeeFirst, String employeeLast, int shiftId, String room) : base(id)
        {
            this.employeeid = employeeid;
            this.date = date;
            this.isOnDuty = isOnDuty;
            this.employeeFirst = employeeFirst;
            this.employeeLast = employeeLast;
            this.shiftId = shiftId;
            this.room = room;
        }



    }
}