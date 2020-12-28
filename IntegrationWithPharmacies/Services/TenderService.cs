using HealthClinic.CL.DbContextModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Services
{
    public class TenderService
    {
        public TenderService(MyDbContext context) {}

        internal bool PublishTender(Tender tender)
        {
            return true;
        }
    }
}
