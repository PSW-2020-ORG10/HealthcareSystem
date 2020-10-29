/***********************************************************************
 * Module:  RegularAppointmentService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.RegularAppointmentService
 ***********************************************************************/
using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;
namespace Class_diagram.Service
{
    public class RegularAppointmentService : bingPath,IStrategyAppointment
    {
        public AppointmentRepository appointmentRepository;
        String path = bingPathToAppDir(@"JsonFiles\appointments.json");
       
        public RegularAppointmentService()
        {
            appointmentRepository = new AppointmentRepository(path);
           
        }
     
        public List<DoctorAppointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }
      
        public void New(DoctorAppointment appointment, Operation operation)
        {
            appointmentRepository.New(appointment);
        }
    
        public void Update(DoctorAppointment appointment, Operation operation)
        {
            appointmentRepository.Update(appointment);
        }
        public void Remove(int appointmentID, int operationID)
        {
            appointmentRepository.Delete(appointmentID);
        }
      
        public DoctorAppointment GetByID(int id)
        {
            return appointmentRepository.GetByID(id);
        }

        public DoctorAppointment RecommendAnAppointment(DoctorUser doctor, DateTime date1, DateTime date2, PatientUser patient)
        {
            TimeSpan time1 = TimeSpan.FromMinutes(15);

            var date = date1;
            while (date <= date2)
            {
                DoctorAppointment foundAppointment = getAvailableTerm(doctor, date, time1, patient);
                if (foundAppointment!=null)
                {
                    return foundAppointment;
                }
                date = date.AddDays(1);
            }

            return null;
        }

        private DoctorAppointment getAvailableTerm(DoctorUser doctor, DateTime date, TimeSpan time1, PatientUser patient)
        {
            EmployeesScheduleController employeesScheduleController = new EmployeesScheduleController();

            String shiftBegin;
            String shiftEnd;
            String dateToString = date.ToString("dd/MM/yyyy");

            Shift doctorShift = employeesScheduleController.getShiftForDoctorForSpecificDay(dateToString, doctor);

            if (doctorShift != null && doctorShift.StartTime != null && doctorShift.EndTime != null)
            {
                shiftBegin = doctorShift.StartTime;
                shiftEnd = doctorShift.EndTime;

                String[] partsBegin = shiftBegin.Split(':');
                String[] partsEnd = shiftEnd.Split(':');

                TimeSpan starnTimeSpan = new TimeSpan(int.Parse(partsBegin[0]), int.Parse(partsBegin[1]), int.Parse("00"));
                TimeSpan endTimeSpan = new TimeSpan(int.Parse(partsEnd[0]), int.Parse(partsEnd[1]), int.Parse("00"));

                for (var time = starnTimeSpan; time <= endTimeSpan; time = time.Add(time1))
                {
                    Boolean notAvailable = isTermNotAvailable(doctor, time, dateToString, patient);

                    if (notAvailable == false)
                    {
                        DoctorAppointment newDoctorAppointment = new DoctorAppointment(0, time, dateToString, patient, doctor, null, doctor.ordination);
                        return newDoctorAppointment;
                    }

                }
            }
            return null;
        }

        public DoctorAppointment recommenedAnAppointmentDatePriority(DateTime date1, DateTime date2, PatientUser patient)
        {
            DoctorController doctorController = new DoctorController();
            List<DoctorUser> doctorsList = doctorController.GetAll();

            TimeSpan time1 = TimeSpan.FromMinutes(15);

            var date = date1;
            while (date <= date2)
            {
                foreach (DoctorUser doctor in doctorsList)
                {
                    if (doctor.Specialist == false)
                    {
                        DoctorAppointment foundAppointment = getAvailableTerm(doctor, date, time1, patient);
                        if (foundAppointment != null)
                        {
                            return foundAppointment;
                        }
                    }
                }
                date = date.AddDays(1);
            }

            return null;
        }

      
        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan time, String dateToString, PatientUser patient)
        {
            PatientController patientController = new PatientController();
            DoctorController doctorController = new DoctorController();
            Boolean hasAppointmentDoctor = doctorController.doesDoctorHaveAnAppointmentAtSpecificTime(doctor, time, dateToString);
            Boolean hasOperationDoctor = doctorController.doesDoctorHaveAnOperationAtSpecificTime(doctor, time, dateToString);
            Boolean hasAppointmentPatient = patientController.doesPatientHaveAnAppointmentAtSpecificTime(time, dateToString, patient);
            Boolean hasOperationPatient = patientController.doesPatientHaveAnOperationAtSpecificTime(time, dateToString, patient);

            if (hasAppointmentDoctor == true || hasAppointmentPatient == true || hasOperationDoctor==true || hasOperationPatient==true)
            {
                return true;
            }
            return false;
        }
     



    }
}