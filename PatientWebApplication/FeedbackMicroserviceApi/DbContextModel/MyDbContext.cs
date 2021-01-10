using FeedbackMicroserviceApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FeedbackMicroserviceApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback(1, "First message", true, true, new DateTime(2020, 11, 2), 1),
                new Feedback(2, "Second message", false, false, new DateTime(2019, 6, 23), 1),
                new Feedback(3, "Third message", true, false, new DateTime(2020, 2, 12), 1),
                new Feedback(4, "Fourth message", true, false, new DateTime(2020, 9, 11), 1)
           );
        }

    }
}
