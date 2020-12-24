/***********************************************************************
 * Module:  EmployeesScheduleRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EmployeesScheduleRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Employee;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IEmployeesScheduleRepository
    {
        void Delete(int id);
        List<Schedule> GetAll();
        Schedule GetByid(int id);
        List<Schedule> GetScheduleForDoctor(string id);
        void New(Schedule schedule);
        void Update(Schedule schedule);
    }
}