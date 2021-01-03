using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public MyDbContext DbContext;

        public MessageRepository()
        {
            DbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public MessageRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Message Create(Message message)
        {
            DbContext.Messages.Add(message);
            DbContext.SaveChanges();
            return message;
        }

        public List<Message> GetAll()
        {
            return DbContext.Messages.ToList();
        }
    }
}