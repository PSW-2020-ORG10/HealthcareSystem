using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Services
{
    public class FeedbackService
    {
        private readonly MyDbContext dbContext;
        public FeedbackService(MyDbContext context)
        {
            dbContext = context;
        }
    }
}
