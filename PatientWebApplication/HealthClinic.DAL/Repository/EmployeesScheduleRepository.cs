/***********************************************************************
 * Module:  EmployeesScheduleRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EmployeesScheduleRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Employee;

namespace HealthClinic.CL.Repository
{
    public class EmployeesScheduleRepository : GenericFileRepository<Schedule>
   {
        public EmployeesScheduleRepository(string filePath) : base(filePath) { }

        public EmployeesScheduleRepository() : base() { }

    }
}