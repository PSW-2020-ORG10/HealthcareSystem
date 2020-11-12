using HealthClinic.BL.Dtos;
using HealthClinic.BL.Model.Patient;
using System;

namespace HealthClinic.BL.Adapters
{
    public class FeedbackAdapter
    {
        /// <summary>This method creates <c>Feedback</c> from provided <paramref name="dto"/> and <paramref name="patient"/>.</summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Feedback</c> that contains <c>Message</c>, <c>IsPublic</c>, <c>IsAnonymous</c> and <c>PatientId</c>.</param>
        /// <param name="patient"><c>patient</c> is <c>PatientUser</c> that has created <c>Feedback</c></param>
        /// <returns> created <c>Feedback</c> </returns>
        public static Feedback FeedbackDtoToFeedback(FeedbackDto dto, PatientUser patient)
        {
            Feedback feedback = new Feedback();
            feedback.Message = dto.Message;
            feedback.Patient = patient;
            feedback.PatientId = patient.id;
            feedback.IsAnonymous = dto.IsAnonymous;
            feedback.IsPublic = dto.IsPublic;
            feedback.Date = DateTime.Now;
            return feedback;
        }

        /// <summary>This method creates <c>FeedbackDto</c> from provided <paramref name="feedback"/>.</summary>
        /// <param name="feedback"><c>feedback</c> is <c>Feedback</c> that will be transfered to <c>FeedbackDto</c>.</param>
        /// <returns> created <c>FeedbackDto</c> </returns>
        public static FeedbackDto FeedbackToFeedbackDto(Feedback feedback)
        {
            FeedbackDto dto = new FeedbackDto();
            dto.Message = feedback.Message;
            dto.IsAnonymous = feedback.IsAnonymous;
            dto.IsPublic = feedback.IsPublic;
            dto.PatientId = feedback.Patient.id;
            return dto;
        }
    }
}
