using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic.BL.Dtos
{
    public class FeedbackDto
    {
        public string Message { get; set; }
        public bool IsPublic { get; set; }
        public bool IsAnonymous { get; set; }
        public int PatientId { get; set; }

        public FeedbackDto() { }
    }
}
