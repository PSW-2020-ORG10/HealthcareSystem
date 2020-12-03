/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Luna
 * Purpose: Definition of the Class Doctor.Doctor
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Contoller
{
    public class DoctorController : IUserController<DoctorUser>
    {
        public DoctorService doctorService;

        public DoctorController()
        {
            doctorService = new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository());
        }


        public List<Room> getAvailableOrdinations()
        {
            return doctorService.getAvailableOrdinations();
        }

        public Boolean Update(DoctorUser doctor)
        {
           return doctorService.Update(doctor);
        }

        public void Remove(DoctorUser doctor)
        {
            doctorService.Remove(doctor);
        }

        public Boolean New(DoctorUser doctor)
        {
           return doctorService.New(doctor);
        }

        public List<DoctorUser> GetAll()
        {
            return doctorService.GetAll();
        }

        public DoctorUser GetByid(int id)
        {
            return doctorService.GetByid(id);
        }
        public Boolean doesDoctorHaveAnAppointmentAtSpecificTime(DoctorUser doctor, TimeSpan time, string date)
        {
            return doctorService.DoesDoctorHaveAnAppointmentAtSpecificTime(doctor, time, date);
        }
        public Boolean doesDoctorHaveAnOperationAtSpecificTime(DoctorUser doctor, TimeSpan time, string date)
        {
            return doctorService.DoesDoctorHaveAnOperationAtSpecificTime(doctor, time, date);
        }

        public bool doesDoctorHaveAnOperationAtSpecificPerod(DoctorUser doctor, TimeSpan start, TimeSpan end, string dateToString)
        {
            return doctorService.doesDoctorHaveAnOperationAtSpecificPeriod(doctor, start, end, dateToString);
        }

        public bool doesDoctorHaveAnAppointmentAtSpecificPeriod(DoctorUser doctor, TimeSpan start, TimeSpan end, string dateToString)
        {
            return doctorService.doesDoctorHaveAnAppointmentAtSpecificPeriod(doctor, start, end, dateToString);
        }
       
    }
}