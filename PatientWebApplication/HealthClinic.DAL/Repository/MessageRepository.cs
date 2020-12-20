using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.ActionsAndBenefits;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public MyDbContext DbContext;

        public MessageRepository()
        {
            //DbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
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