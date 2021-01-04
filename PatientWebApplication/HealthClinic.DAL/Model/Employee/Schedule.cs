/***********************************************************************
 * Module:  Schedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Schedule
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Employee
{
    public class Schedule : Entity
    {
        public virtual EmployeeUser Employee { get; set; }
        public int EmployeeId { get; set; }

        public string date { get; set; }
        public bool isOnDuty { get; set; }

        public int shiftId { get; set; }
        public virtual Shift shift { get; set; }

        public string room { get; set; }
        public Schedule() : base() { }

        public Schedule(int id, int employeeId, string date, bool isOnDuty, int shiftId, string room) : base(id)
        {
            this.EmployeeId = employeeId;
            this.date = date;
            this.isOnDuty = isOnDuty;
            this.shiftId = shiftId;
            this.room = room;
        }

        public Schedule(int id, int employeeId, string date, bool isOnDuty, Shift shift, string room) : base(id)
        {
            this.EmployeeId = employeeId;
            this.date = date;
            this.isOnDuty = isOnDuty;
            this.shift = shift;
            this.room = room;
        }
    }
}