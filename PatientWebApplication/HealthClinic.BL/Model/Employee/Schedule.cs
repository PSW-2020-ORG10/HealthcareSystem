/***********************************************************************
 * Module:  Schedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Schedule
 ***********************************************************************/

using HealthClinic.BL.Model.Patient;

namespace HealthClinic.BL.Model.Employee
{
    public class Schedule : Entity
    {
        public string employeeFirst { get; set; }
        public string employeeLast { get; set; }
        public string employeeid { get; set; }

        public string date { get; set; }
        public bool isOnDuty { get; set; }

        public int shiftId { get; set; }
        public virtual Shift shift { get; set; }

        public string room { get; set; }
        public Schedule() : base() { }


        public Schedule(int id, string employeeid, string date, bool isOnDuty, string employeeFirst, string employeeLast, Shift shift, string room) : base(id)
        {
            this.employeeid = employeeid;
            this.date = date;
            this.isOnDuty = isOnDuty;
            this.employeeFirst = employeeFirst;
            this.employeeLast = employeeLast;
            this.shift = shift;
            this.room = room;
        }

        public Schedule(int id, string employeeid, string date, bool isOnDuty, string employeeFirst, string employeeLast, int shiftId, string room) : base(id)
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