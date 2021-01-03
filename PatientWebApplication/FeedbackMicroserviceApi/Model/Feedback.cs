using System;

namespace FeedbackMicroserviceApi.Model
{
    public class Feedback : Entity
    {

        public string Message { get; set; }
        public bool IsPublished { get; set; }
        public bool IsPublic { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime Date { get; set; }
        public int PatientId { get; set; }

        public Feedback(int id, string message, bool isPublished, bool isPublic, bool isAnonymous, DateTime date, int patientId) : base(id)
        {
            Message = message;
            IsPublished = isPublished;
            IsPublic = isPublic;
            IsAnonymous = isAnonymous;
            Date = date;
            PatientId = patientId;
        }

        public Feedback(int id, string message, bool isPublic, bool isAnonymous, DateTime date, int patientId) : base(id)
        {
            Message = message;
            IsPublished = false;
            IsPublic = isPublic;
            IsAnonymous = isAnonymous;
            Date = date;
            PatientId = patientId;
        }

        //Empty constructor
        public Feedback() : base()
        {
            Message = "";
            IsPublished = false;
            IsPublic = false;
            IsAnonymous = false;
            Date = new DateTime();
            PatientId = 0;
        }

        public Feedback(string message, bool isPublic, bool isAnonymous, DateTime date, int patientId) : base()
        {
            Message = message;
            IsPublished = false;
            IsPublic = isPublic;
            IsAnonymous = isAnonymous;
            Date = date;
            PatientId = patientId;
        }


    }
}
