/***********************************************************************
 * Module:  Operation.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Doctor.Operation
 ***********************************************************************/

using System;
using AppointmentMicroserviceApi.Model;

namespace AppointmentMicroserviceApi.Doctor
{
    public class Operation : Appointment
    {
        public TimeSpan end { get; set; }
        public virtual OperationReferral operationReferral { get; set; }
        public Operation() : base() { }
        public Operation(int id, string date, TimeSpan start, TimeSpan end, string roomId, OperationReferral operationReferral) : base(id, start, date, roomId)
        {
            this.end = end;
            this.operationReferral = operationReferral;
        }

        public Operation(int id, int patientId, string date, TimeSpan start, TimeSpan end, int isResponiableId, string roomId, int operationReferralId) : base(id, start, date, patientId, isResponiableId, roomId)
        {
            this.end = end;
        }

        public Operation(int id, int patientId, string date, TimeSpan start, TimeSpan end, int isResponiableId, string roomId) : base(id, start, date, patientId, isResponiableId, roomId)
        {
            this.end = end;
        }
    }
}