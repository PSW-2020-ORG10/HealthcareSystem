/***********************************************************************
 * Module:  Shift.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Shift
 ***********************************************************************/

namespace UserMicroserviceApi.Model
{
    public class Shift : Entity
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public Shift() {}

        public Shift(string startTime, string endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public Shift(int id, string startTime, string endTime) : base(id)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}