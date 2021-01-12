using EventStore.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EventStore.EventDBContext
{
    public class EventDbContext: DbContext
    {
        public DbSet<FeedbackSubmittedEvent> FeedbackSubmittedEvents { get; set; }

        public EventDbContext(DbContextOptions options)
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(CreateConnectionStringFromEnvironment());
            }
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "EventsDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"server={server};port={port};database={database};user={user};password={password}";

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FeedbackSubmittedEvent>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.TimeStamp).IsRequired();
                entity.Property(e => e.FeedbackID).IsRequired();
                entity.Property(e => e.Message).IsRequired();
                entity.Property(e => e.PatientID).IsRequired();
            });
        }
    }
}
