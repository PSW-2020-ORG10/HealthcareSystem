using FeedbackMicroserviceApi.Dtos;
using FeedbackMicroserviceApi.Model;
using System;
using System.Collections.Generic;

namespace FeedbackMicroserviceApi.Adapters
{
    public static class FeedbackAdapter
    {
        /// <summary>This method creates <c>Feedback</c> from provided <paramref name="dto"/> and <paramref name="patient"/>.</summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Feedback</c> that contains <c>Message</c>, <c>IsPublic</c>, <c>IsAnonymous</c> and <c>PatientId</c>.</param>
        /// <param name="patient"><c>patient</c> is <c>PatientUser</c> that has created <c>Feedback</c></param>
        /// <returns> created <c>Feedback</c> </returns>
        public static Feedback FeedbackDtoToFeedback(FeedbackDto dto)
        {
            return new Feedback(dto.Message, dto.IsPublic, dto.IsAnonymous, DateTime.Now, 2);
        }

        /// <summary>This method creates <c>FeedbackDto</c> from provided <paramref name="feedback"/>.</summary>
        /// <param name="feedback"><c>feedback</c> is <c>Feedback</c> that will be transfered to <c>FeedbackDto</c>.</param>
        /// <returns> created <c>FeedbackDto</c> </returns>
        public static FeedbackDto FeedbackToFeedbackDto(Feedback feedback)
        {
            return new FeedbackDto(feedback.Message, feedback.IsPublic, feedback.IsAnonymous, 2);
        }

        public static MicroserviceFeedbackDto FeedbackToMicroserviceFeedbackDto(Feedback feedback)
        {
            return new MicroserviceFeedbackDto(Utility.HttpRequests.GetOnePatient(feedback.PatientId).Result, feedback.Message, feedback.IsPublic, feedback.IsAnonymous, feedback.Date, feedback.PatientId);
        }

        public static List<MicroserviceFeedbackDto> FeedbackListToMicroserviceFeedbackDtoList(List<Feedback> feedbacks)
        {
            List<MicroserviceFeedbackDto> microserviceFeedbackDtos = new List<MicroserviceFeedbackDto>();
            foreach(Feedback feedback in feedbacks)
            {
                microserviceFeedbackDtos.Add(FeedbackToMicroserviceFeedbackDto(feedback));
            }
            return microserviceFeedbackDtos;
        }


    }
}
