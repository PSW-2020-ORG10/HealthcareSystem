/***********************************************************************
 * Module:  DoctorAppointment.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Patient.DoctorAppointment
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic.CL.Model.Patient
{
    public class DoctorAppointment : Appointment
    {
        [ForeignKey("AppointmentId")]
        public virtual List<Referral> referral { get; set; }
        public bool IsCanceled { get; set; }
        public String CancelDateString { get; set; }

        public DoctorAppointment(int id, TimeSpan time, string date, PatientUser patient, DoctorUser doctor, List<Referral> referrals, string roomid) : base(id, time, date, patient, doctor, roomid)
        {
            referral = referrals;
            IsCanceled = false;
            CancelDateString = null;
        }
     
        public DoctorAppointment(int id, TimeSpan time, string date, int patientId, int doctorId, List<Referral> referrals, string roomid) : base(id, time, date, patientId, doctorId, roomid)
        {
            referral = referrals;
            IsCanceled = false;
            CancelDateString = null;
        }

        public DoctorAppointment() : base() { }

        public override bool Equals(Object obj)
        {
            var item = obj as DoctorAppointment;
            if (item == null)
            {
                return false;
            }
            return UtilityMethods.CheckIfStringsMatch(this.Date, item.Date) && this.DoctorUserId == item.DoctorUserId && this.PatientUserId == item.PatientUserId && UtilityMethods.CheckIfStringsMatch(this.RoomId, item.RoomId);
        }

    }
}