using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Dtos
{
    public class FeedbackDto
    {
        public String Message { get; set; }
        public Boolean IsPublic { get; set; }
        public Boolean IsAnonymous { get; set; }

        public FeedbackDto() { }
    }
}
