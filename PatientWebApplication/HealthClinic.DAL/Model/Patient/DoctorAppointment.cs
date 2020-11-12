/***********************************************************************
 * Module:  DoctorAppointment.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Patient.DoctorAppointment
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Patient
{
    public class DoctorAppointment : Entity
    {
        public virtual List<Referral> referral { get; set; }
        public int doctorUserId { get; set; }
        public virtual DoctorUser doctor { get; set; }

        public TimeSpan time { get; set; }
        public string date { get; set; }
        public int patientUserId { get; set; }
        public virtual PatientUser patient { get; set; }
        public string roomid { get; set; }


        public DoctorAppointment(int id, TimeSpan time, string date, PatientUser patient, DoctorUser doctor, List<Referral> referrals, string roomid) : base(id)
        {
            this.time = time;
            this.date = date;
            this.patient = patient;
            this.doctor = doctor;
            referral = referrals;
            this.roomid = roomid;

        }

        public DoctorAppointment(int id, TimeSpan time, string date, int patientId, int doctorId, List<Referral> referrals, string roomid) : base(id)
        {
            this.time = time;
            this.date = date;
            patientUserId = patientId;
            doctorUserId = doctorId;
            referral = referrals;
            this.roomid = roomid;

        }

        public DoctorAppointment() : base() { }

    }
}