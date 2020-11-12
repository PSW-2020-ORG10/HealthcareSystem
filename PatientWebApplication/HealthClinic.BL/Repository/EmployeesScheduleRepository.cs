/***********************************************************************
 * Module:  EmployeesScheduleRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EmployeesScheduleRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Employee;
using System;

namespace HealthClinic.BL.Repository
{
    public class EmployeesScheduleRepository : GenericFileRepository<Schedule>
   {
        public EmployeesScheduleRepository(string filePath) : base(filePath) { }

        public EmployeesScheduleRepository() : base() { }

    }
}