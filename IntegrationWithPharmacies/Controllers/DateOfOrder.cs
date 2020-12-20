using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Controllers
{
    public class DateOfOrder
    {
        public String StartDate { get; set; }
        public String EndDate { get; set; }

        public DateOfOrder() { }

        public DateOfOrder(String Start, String End)
        {
            StartDate = Start;
            EndDate = End;
        }
    }
}
