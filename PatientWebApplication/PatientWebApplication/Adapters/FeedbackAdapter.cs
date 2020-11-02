using Class_diagram.Model.Patient;
using PatientWebApplication.Dtos;

namespace PatientWebApplication.Adapters
{
    public class FeedbackAdapter
    {
        public static Feedback FeedbackDtoToFeedback(FeedbackDto dto, PatientUser patient)
        {
            Feedback feedback = new Feedback();
            feedback.Message = dto.Message;
            feedback.Patient = patient;
            feedback.PatientId = patient.id;
            feedback.IsAnonymous = dto.IsAnonymous;
            feedback.IsPublic = dto.IsPublic;
            return feedback;
        }

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
