using EventStore.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore
{
    public class EventDbContext : DbContext
    {
        public DbSet<FeedbackSubmittedEvent> FeedbackSubmittedEvents { get; set; }

        public EventDbContext() { }
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "EventsDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"server={server};port={port};database={database};user={user};password={password}";
           
        }

        public EventDbContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder<EventDbContext>();
            return new EventDbContext(builder.UseMySql(CreateConnectionStringFromEnvironment()).Options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
