/***********************************************************************
 * Module:  AppointmentController.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.AppointmentController
 ***********************************************************************/
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using System;
using System.Collections.Generic;
namespace HealthClinic.CL.Contoller
{
    public class AppointmentController 
    {
        public ContextAppointmentService contextAppointmentService;
        public RegularAppointmentService regularAppointmentService;

        public AppointmentController()
        {
            regularAppointmentService = new RegularAppointmentService(new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository()), new PatientsRepository(), new OperationService(new OperationRepository()));
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

        public DoctorAppointment DoctorAppointment(int id)
        {
            return regularAppointmentService.GetByid(id);
        }

        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan time, String dateToString, PatientUser patient)
        {
            return regularAppointmentService.IsTermNotAvailable(doctor, time, dateToString, patient);
        }
        public DoctorAppointment RecommendAnAppointment(DoctorUser doctor, DateTime date1, DateTime date2, PatientUser patient)
        {
            return regularAppointmentService.RecommendAnAppointment(doctor, date1, date2, patient);
        }
        public List<DoctorAppointment> recommenedAnAppointmentDatePriority(DateTime date1, DateTime date2, PatientUser patient)
        {
            return regularAppointmentService.RecommenedAnAppointmentDatePriority(date1, date2, patient, "Speciality");
        }


        }
}