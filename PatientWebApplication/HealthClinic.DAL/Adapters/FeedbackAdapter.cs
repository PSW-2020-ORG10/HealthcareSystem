using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Adapters
{
    public class FeedbackAdapter
    {
        /// <summary>This method creates <c>Feedback</c> from provided <paramref name="dto"/> and <paramref name="patient"/>.</summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Feedback</c> that contains <c>Message</c>, <c>IsPublic</c>, <c>IsAnonymous</c> and <c>PatientId</c>.</param>
        /// <param name="patient"><c>patient</c> is <c>PatientUser</c> that has created <c>Feedback</c></param>
        /// <returns> created <c>Feedback</c> </returns>
        public static Feedback FeedbackDtoToFeedback(FeedbackDto dto, PatientUser patient)
        {
            return new Feedback(dto.Message, dto.IsPublic, dto.IsAnonymous, DateTime.Now, patient.id, patient);
        }

        /// <summary>This method creates <c>FeedbackDto</c> from provided <paramref name="feedback"/>.</summary>
        /// <param name="feedback"><c>feedback</c> is <c>Feedback</c> that will be transfered to <c>FeedbackDto</c>.</param>
        /// <returns> created <c>FeedbackDto</c> </returns>
        public FeedbackDto FeedbackToFeedbackDto(Feedback feedback)
        {
            return new FeedbackDto(feedback.Message, feedback.IsPublic, feedback.IsAnonymous, feedback.Patient.id);
        }

       
    }
}
