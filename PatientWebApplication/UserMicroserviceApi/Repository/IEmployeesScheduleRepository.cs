/***********************************************************************
 * Module:  EmployeesScheduleRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EmployeesScheduleRepository
 ***********************************************************************/

using System.Collections.Generic;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
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