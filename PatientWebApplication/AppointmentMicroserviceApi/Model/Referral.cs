/***********************************************************************
 * Module:  Referral.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Doctor.Referral
 ***********************************************************************/
using AppointmentMicroserviceApi.Model;

namespace AppointmentMicroserviceApi.Doctor
{

    public class Referral : Entity
    {
        public string Diagnosis { get; set; }
        public string Procedure { get; set; }
        public int AppointmentId { get; set; }

        public Referral() : base() { }
        public Referral(int id, string diagnosis, string procedure) : base(id)

        {
            Diagnosis = diagnosis;
            Procedure = procedure;
        }

        public Referral(int id, string diagnosis, string procedure, int appointmentId) : base(id)

        {
            Diagnosis = diagnosis;
            Procedure = procedure;
            AppointmentId = appointmentId;
        }
    }
}