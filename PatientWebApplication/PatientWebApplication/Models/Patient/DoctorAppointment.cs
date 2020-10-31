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


        public List<Referral> referral { get; set; }

        public DoctorUser doctor { get; set; }

        public TimeSpan Time { get; set; }
        public String Date { get; set; }
        public PatientUser patient { get; set; }
        public String roomID { get; set; }


        public DoctorAppointment(int id, TimeSpan time, String date, PatientUser pat, DoctorUser doc, List<Referral> referrals, String room) : base(id)
        {
            this.Time = time;
            this.Date = date;
            this.patient = pat;
            this.doctor = doc;
            this.referral = referrals;
            this.roomID = room;

        }

        public DoctorAppointment() : base() { }

    }
}