/***********************************************************************
 * Module:  Operation.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Doctor.Operation
 ***********************************************************************/

using System;
using HealthClinic.BL.Model.Patient;

namespace HealthClinic.BL.Model.Doctor
{
    public class Operation : Entity
    {
        public int PatientUserId { get; set; }
        public virtual PatientUser patient { get; set; }
        public string date { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }
        public int DoctorUserId { get; set; }
        public virtual DoctorUser isResponiable { get; set; }
        public string idRoom { get; set; }
        public int OperationReferralId { get; set; }
        public virtual Referral operationReferral { get; set; }
        public Operation() : base() { }
        public Operation(int id, PatientUser patient, string date, TimeSpan start, TimeSpan end, DoctorUser isResponiable, string idRoom, Referral operationReferral) : base(id)
        {
            this.patient = patient;
            this.date = date;
            this.start = start;
            this.end = end;
            this.isResponiable = isResponiable;
            this.idRoom = idRoom;
            this.operationReferral = operationReferral;
        }

        public Operation(int id, int patientId, string date, TimeSpan start, TimeSpan end, int isResponiableId, string idRoom, int operationReferralId) : base(id)
        {
            PatientUserId = patientId;
            this.date = date;
            this.start = start;
            this.end = end;
            DoctorUserId = isResponiableId;
            this.idRoom = idRoom;
            OperationReferralId = operationReferralId;
        }
    }
}