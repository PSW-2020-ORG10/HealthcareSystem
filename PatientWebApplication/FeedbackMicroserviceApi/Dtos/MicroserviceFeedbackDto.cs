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

        public MicroserviceFeedbackDto(int id, bool isPublished, MicroservicePatientDto patient, string message, bool isPublic, bool isAnonymous, DateTime date, int patientId) : base(id, message, isPublished, isPublic, isAnonymous, date, patientId)
        {
            Patient = patient;
        }
    }
}
