/***********************************************************************
 * Module:  EmployeesScheduleRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.EmployeesScheduleRepository
 ***********************************************************************/

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public class EmployeesScheduleRepository : IEmployeesScheduleRepository
    {
        private readonly MyDbContext dbContext;
        public EmployeesScheduleRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EmployeesScheduleRepository()
        {
            dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public void New(Schedule schedule)
        {
            dbContext.Schedules.Add(schedule);
            dbContext.SaveChanges();
        }

        public void Update(Schedule schedule)
        {
            dbContext.Schedules.Update(schedule);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Schedules.Remove(GetByid(id));
            dbContext.SaveChanges();
        }

        public List<Schedule> GetAll()
        {
            return dbContext.Schedules.ToList();
        }

        public Schedule GetByid(int id)
        {
            return dbContext.Schedules.SingleOrDefault(schedule => schedule.Id == id);
        }

        public List<Schedule> GetScheduleForDoctor(string id)
        {
            return dbContext.Schedules.ToList().FindAll(schedule => schedule.EmployeeId.ToString().Equals(id));
        }
    }
}