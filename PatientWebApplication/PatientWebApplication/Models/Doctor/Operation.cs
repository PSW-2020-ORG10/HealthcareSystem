/***********************************************************************
 * Module:  Operation.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Doctor.Operation
 ***********************************************************************/

using System;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Doctor;

namespace Class_diagram.Model.Doctor
{
    public class Operation : Entity
    {
        public PatientUser patient { get; set; }

        public String Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public DoctorUser Responsable { get; set; }
        public String IdRoom { get; set; }
        public Referral OperationReferral { get; set; }
     public Operation() : base()
        {

        }
        public Operation(int id, PatientUser pat, String date, TimeSpan times, TimeSpan end, DoctorUser responsible, String room, Referral referral) : base(id)
        {
            this.patient = pat;
            this.Date = date;
            this.Start = times;
            this.End = end;
            this.Responsable = responsible;
            this.IdRoom = room;
            this.OperationReferral = referral;
        }

        
    }
}