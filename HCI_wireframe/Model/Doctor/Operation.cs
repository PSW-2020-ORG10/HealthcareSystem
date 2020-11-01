/***********************************************************************
 * Module:  Operation.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Doctor.Operation
 ***********************************************************************/

using System;
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Doctor;

namespace Class_diagram.Model.Doctor
{
    public class Operation : Entity
    {
        public PatientUser patient { get; set; }

        public String date { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }
        public DoctorUser isResponiable { get; set; }
        public String idRoom { get; set; }
        public Referral operationReferral { get; set; }
        public Operation() : base()  {}
        public Operation(int id, PatientUser patient, String date, TimeSpan start, TimeSpan end, DoctorUser isResponiable, String idRoom, Referral operationReferral) : base(id)
        {
            this.patient = patient;
            this.date = date;
            this.start = start;
            this.end = end;
            this.isResponiable = isResponiable;
            this.idRoom = idRoom;
            this.operationReferral = operationReferral;
        }

        
    }
}