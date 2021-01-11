using System;

namespace TenderApi.Model
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
