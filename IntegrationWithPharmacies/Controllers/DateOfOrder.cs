using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Controllers
{
    public class DateOfOrder
    {
        public String startDate { get; set; }
        public String endDate { get; set; }

        public DateOfOrder(String start, String end)
        {
            startDate = start;
            endDate = end;
        }
        public DateOfOrder() { }
        
    }
}
