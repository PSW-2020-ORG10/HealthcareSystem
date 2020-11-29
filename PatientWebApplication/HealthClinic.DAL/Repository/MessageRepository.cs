using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MyDbContext dbContext;
        
        public MessageRepository()
        {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public Message Create(Message message)
        {
            dbContext.Messages.Add(message);
            dbContext.SaveChanges();
            return message;
        }

        public List<Message> GetAll()
        {
            return dbContext.Messages.ToList();
        }
    }
}
