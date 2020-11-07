using Class_diagram.Model.Patient;
using System;

namespace Class_diagram.Model.Patient
{
    public class Feedback : Entity
    {

        public String Message { get; set; }
        public Boolean IsPublished { get; set; }
        public Boolean IsPublic { get; set; }
        public Boolean IsAnonymous { get; set; }
        public DateTime Date { get; set; }
        public virtual PatientUser Patient { get; set; }
        public int PatientId { get; set; }

        public Feedback(int id, string message, bool isPublished, bool isPublic, bool isAnonymous, DateTime date, int patientId, PatientUser patient) : base(id)
        {
            Message = message;
            IsPublished = isPublished;
            IsPublic = isPublic;
            IsAnonymous = isAnonymous;
            Date = date;
            Patient = patient;
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
            Patient = new PatientUser();
            PatientId = 0;
        }

        //This constructor is for creating feedback by patient without IsPublished
        public Feedback(int id, string message, bool isPublic, bool isAnonymous, DateTime date, int patientId, PatientUser patient) : base(id)
        {
            Message = message;
            IsPublished = false;
            IsPublic = isPublic;
            IsAnonymous = isAnonymous;
            Date = date;
            Patient = patient;
            PatientId = patientId;
        }


    }
}
