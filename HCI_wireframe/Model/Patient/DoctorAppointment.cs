/***********************************************************************
 * Module:  DoctorAppointment.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Patient.DoctorAppointment
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;

namespace Class_diagram.Model.Patient
{
    public class DoctorAppointment : Entity
    {
        public virtual List<Referral> referral { get; set; }
        public int doctorUserId { get; set; }
        public virtual DoctorUser doctor { get; set; }

        public TimeSpan time { get; set; }
        public String date { get; set; }
        public int patientUserId { get; set; }
        public virtual PatientUser patient { get; set; }
        public String roomid { get; set; }


        public DoctorAppointment(int id, TimeSpan time, String date, PatientUser patient, DoctorUser doctor, List<Referral> referrals, String roomid) : base(id)
        {
            this.time = time;
            this.date = date;
            this.patient = patient;
            this.doctor = doctor;
            this.referral = referrals;
            this.roomid = roomid;

        }

        public DoctorAppointment(int id, TimeSpan time, String date,int patientId, int doctorId, List<Referral> referrals, String roomid) : base(id)
        {
            this.time = time;
            this.date = date;
            this.patientUserId = patientId;
            this.doctorUserId = doctorId;
            this.referral = referrals;
            this.roomid = roomid;

        }

        public DoctorAppointment() : base() { }

    }
}