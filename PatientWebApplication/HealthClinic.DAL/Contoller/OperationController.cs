/***********************************************************************
 * Module:  OperationController.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Contoller.OperationController
 ***********************************************************************/
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using System;
using System.Collections.Generic;
namespace HealthClinic.CL.Contoller
{
    public class OperationController 
    {
        public OperationService operationService;
        public ContextAppointmentService contextAppointmentService;

        public OperationController()
        {
            operationService = new OperationService(new OperationRepository());
            contextAppointmentService = new ContextAppointmentService(operationService);
        }

        public List<Operation> GetAll()
        {
            return operationService.GetAll();
        }

        public Operation GetByid(int id)
        {
            return operationService.GetByid(id);
        }

        public void New(DoctorAppointment appointment, Operation operation)
        {
            contextAppointmentService.New(appointment, operation);
        }

        public void Remove(int appointmentid, int operationid)
        {
            contextAppointmentService.Remove(appointmentid, operationid);
        }

        public void Update(DoctorAppointment appointment, Operation operation)
        {
            contextAppointmentService.Update(appointment, operation);
        }

        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan start, TimeSpan end, String dateToString, PatientUser patient)
        {
            return operationService.isTermNotAvailable( doctor, start, end, dateToString,patient);
        }
      

    }
}