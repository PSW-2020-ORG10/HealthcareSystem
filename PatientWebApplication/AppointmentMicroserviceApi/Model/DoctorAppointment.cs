/***********************************************************************
 * Module:  DoctorAppointment.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Patient.DoctorAppointment
 ***********************************************************************/

using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Model;
using AppointmentMicroserviceApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentMicroserviceApi.Patient
{
    public class DoctorAppointment : Appointment
    {
        [ForeignKey("AppointmentId")]
        public virtual List<Referral> Referral { get; set; }
        public bool IsCanceled { get; set; }
        public String CancelDateString { get; set; }

        public DoctorAppointment(int id, TimeSpan time, string date, List<Referral> referrals, string roomid) : base(id, time, date, roomid)
        {
            Referral = referrals;
            IsCanceled = false;
            CancelDateString = null;
        }
     
        public DoctorAppointment(int id, TimeSpan time, string date, int patientId, int doctorId, List<Referral> referrals, string roomid) : base(id, time, date, patientId, doctorId, roomid)
        {
            Referral = referrals;
            IsCanceled = false;
            CancelDateString = null;
        }

        public DoctorAppointment(int id, TimeSpan time, string date, int patientId, int doctorId, List<Referral> referrals, string roomid, bool isCanceled, string cancelDateString) : base(id, time, date, patientId, doctorId, roomid)
        {
            Referral = referrals;
            IsCanceled = isCanceled;
            CancelDateString = cancelDateString;
        }

        public DoctorAppointment() : base() { }

        public override bool Equals(Object obj)
        {
            DoctorAppointment item = obj as DoctorAppointment;
            if (item == null)
            {
                return false;
            }
            return UtilityMethods.CheckIfStringsMatch(this.Date, item.Date) && this.DoctorUserId == item.DoctorUserId && this.PatientUserId == item.PatientUserId && UtilityMethods.CheckIfStringsMatch(this.RoomId, item.RoomId) && this.Start == item.Start;
        }

    }
}