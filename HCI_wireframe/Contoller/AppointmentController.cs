/***********************************************************************
 * Module:  AppointmentController.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.AppointmentController
 ***********************************************************************/
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Service;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;
namespace Class_diagram.Contoller
{
    public class AppointmentController 
    {
        public ContextAppointmentService contextAppointmentService;
        public RegularAppointmentService regularAppointmentService;

        public AppointmentController()
        {
            regularAppointmentService = new RegularAppointmentService();
            contextAppointmentService = new ContextAppointmentService(regularAppointmentService);
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
       
        public List<DoctorAppointment> GetAll()
        {
            return regularAppointmentService.GetAll();
        }

        public DoctorAppointment GetByid(int id)
        {
            return regularAppointmentService.GetByid(id);
        }

        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan time, String dateToString, PatientUser patient)
        {
            return regularAppointmentService.isTermNotAvailable(doctor, time, dateToString, patient);
        }
        public DoctorAppointment RecommendAnAppointment(DoctorUser doctor, DateTime date1, DateTime date2, PatientUser patient)
        {
            return regularAppointmentService.RecommendAnAppointment(doctor, date1, date2, patient);
        }
        public DoctorAppointment recommenedAnAppointmentDatePriority(DateTime date1, DateTime date2, PatientUser patient)
        {
            return regularAppointmentService.recommenedAnAppointmentDatePriority(date1, date2, patient);
        }


        }
}