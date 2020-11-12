/***********************************************************************
 * Module:  Shift.cs
 * Author:  Luna
 * Purpose: Definition of the Class Employee.Shift
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Employee
{
    public class Shift : Entity
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public Shift()
        {

        }
        public Shift(string start, string end)
        {
            startTime = start;
            endTime = end;
        }

        public Shift(int id, string start, string end) : base(id)
        {
            startTime = start;
            endTime = end;
        }




    }
}