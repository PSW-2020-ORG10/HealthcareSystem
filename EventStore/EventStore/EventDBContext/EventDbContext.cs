using EventStore.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore.EventDBContext
{
    public class EventDbContext: DbContext
    {
        public DbSet<FeedbackSubmittedEvent> FeedbackSubmittedEvents { get; set; }

        public EventDbContext(){}

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
