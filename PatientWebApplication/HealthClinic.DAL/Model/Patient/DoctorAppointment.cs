/***********************************************************************
 * Module:  DoctorAppointment.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Patient.DoctorAppointment
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.CL.Model.Patient
{
    public class DoctorAppointment : Appointment
    {
        [ForeignKey("AppointmentId")]
        public virtual List<Referral> referral { get; set; }

        public DoctorAppointment(int id, TimeSpan time, string date, PatientUser patient, DoctorUser doctor, List<Referral> referrals, string roomid) : base(id, time, date, patient, doctor, roomid)
        {
            referral = referrals;
        }

        public DoctorAppointment(int id, TimeSpan time, string date, int patientId, int doctorId, List<Referral> referrals, string roomid) : base(id, time, date, patientId, doctorId, roomid)
        {
            referral = referrals;
        }

        public DoctorAppointment() : base() { }

    }
}