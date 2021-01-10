using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly MyDbContext dbContext;
        public AdministratorRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AdministratorRepository()
        {
            dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public void New(Administrator admin)
        {
            dbContext.Administrators.Add(admin);
            dbContext.SaveChanges();
        }

        public void Update(Administrator admin)
        {
            dbContext.Administrators.Update(admin);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Administrators.Remove(GetByid(id));
            dbContext.SaveChanges();
        }

        public List<Administrator> GetAll()
        {
            return dbContext.Administrators.ToList();
        }

        public Administrator GetByid(int id)
        {
            return dbContext.Administrators.SingleOrDefault(admin => admin.Id == id);
        }

        public Administrator GetByLoginInfo(UserModel login)
        {
            return dbContext.Administrators.SingleOrDefault(admin => admin.Email.Equals(login.Email) && admin.Password.Equals(login.Password));
        }
    }
}
