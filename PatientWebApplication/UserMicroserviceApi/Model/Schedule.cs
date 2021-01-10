/***********************************************************************
 * Module:  Schedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Schedule
 ***********************************************************************/

namespace UserMicroserviceApi.Model
{
    public class Schedule : Entity
    {
        public virtual EmployeeUser Employee { get; set; }
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public bool IsOnDuty { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        public string Room { get; set; }

        public Schedule() : base() { }

        public Schedule(int id, int employeeId, string date, bool isOnDuty, int shiftId, string room) : base(id)
        {
            EmployeeId = employeeId;
            Date = date;
            IsOnDuty = isOnDuty;
            ShiftId = shiftId;
            Room = room;
        }

        public Schedule(int id, int employeeId, string date, bool isOnDuty, Shift shift, string room) : base(id)
        {
            EmployeeId = employeeId;
            Date = date;
            IsOnDuty = isOnDuty;
            Shift = shift;
            Room = room;
        }
    }
}