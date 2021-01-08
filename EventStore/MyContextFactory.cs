using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;




namespace EventStore
{
    public class MyContextFactory : IDesignTimeDbContextFactory<EventDbContext>
    {
       
        public EventDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EventDbContext>();
            var connectionString = "server=localhost;port=3306;database=eventlogstore;user=root;password=root";
            return new EventDbContext(builder.UseMySql(connectionString).Options);
        }
    }
}
