/***********************************************************************
 * Module:  EmployeesScheduleRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EmployeesScheduleRepository
 ***********************************************************************/

using Class_diagram.Model.Employee;
using System;

namespace Class_diagram.Repository
{
   public class EmployeesScheduleRepository : GenericFileRepository<Schedule>
   {
        public EmployeesScheduleRepository(string filePath) : base(filePath) { }

        public EmployeesScheduleRepository() : base() { }

    }
}