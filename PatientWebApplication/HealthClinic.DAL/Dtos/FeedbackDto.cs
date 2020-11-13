using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic.CL.Dtos
{
    public class FeedbackDto
    {
        public string Message { get; set; }
        public bool IsPublic { get; set; }
        public bool IsAnonymous { get; set; }
        public int PatientId { get; set; }

        public FeedbackDto() { }

        public FeedbackDto(string message, bool isPublic, bool isAnonymous, int patientId)
        {
            Message = message;
            IsPublic = isPublic;
            IsAnonymous = isAnonymous;
            PatientId = patientId;
        }
    }
}
