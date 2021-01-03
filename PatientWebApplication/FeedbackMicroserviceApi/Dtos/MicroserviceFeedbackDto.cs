using FeedbackMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroserviceApi.Dtos
{
    public class MicroserviceFeedbackDto : Feedback
    {
        public MicroservicePatientDto Patient { get; set; }

        public MicroserviceFeedbackDto(MicroservicePatientDto patient, string message, bool isPublic, bool isAnonymous, DateTime date, int patientId) : base(message, isPublic, isAnonymous, date, patientId)
        {
            Patient = patient;
        }
    }
}
