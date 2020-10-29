/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Luna
 * Purpose: Definition of the Class Doctor.Doctor
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Repository;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Class_diagram.Service
{
   public class DoctorService : AbstractUserService<DoctorUser>
    {
        public OperationRepository operationRepository;
        public PatientsRepository patientsRepository;
        public DoctorRepository doctorRepository;
        public AppointmentRepository appointmentRepository;
        public EmployeesScheduleRepository employeesScheduleRepository;

        String path = bingPathToAppDir(@"JsonFiles\doctors.json");
        String path2 = bingPathToAppDir(@"JsonFiles\patients.json");
        String path3 = bingPathToAppDir(@"JsonFiles\operations.json");
        String path4 = bingPathToAppDir(@"JsonFiles\appointments.json");
        String path5 = bingPathToAppDir(@"JsonFiles\schedule.json");


        public DoctorService()
        {
            doctorRepository = new DoctorRepository(path);
            patientsRepository = new PatientsRepository(path2);
            operationRepository = new OperationRepository(path3);
            appointmentRepository = new AppointmentRepository(path4);
            employeesScheduleRepository = new EmployeesScheduleRepository(path5);
           
        }
        public override List<DoctorUser> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public override Boolean New(DoctorUser doctor)
        {
            if (isDataValid(doctor.Email, doctor.UniqueCitizensIdentityNumber,doctor) && isCityValid(doctor.city))
            {
                doctorRepository.New(doctor);
                return true;
            }
            return false;
        }

        public override Boolean Update(DoctorUser doctor)
        {
            if (isDataValid(doctor.Email, doctor.UniqueCitizensIdentityNumber,doctor) && isCityValid(doctor.city))
            {
                doctorRepository.Update(doctor);
                return true;
            }
            return false;
        }

        public override DoctorUser GetByID(int ID)
        {
            return doctorRepository.GetByID(ID);
        }

        public override void Remove(DoctorUser doctor)
        {
            doctorRepository.Delete(doctor.ID);
            removeDoctorFromSchedule(doctor);
        }

        public List<Room> getAvailableOrdinations()
        {

            RoomController roomController = new RoomController();
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomController.GetAll();
            List<Room> roomsForUse = new List<Room>();
            List<Room> availableOrdinations = new List<Room>();
            DoctorController doctorController = new DoctorController();
            List<DoctorUser> listOfDoctors = doctorController.GetAll();

                foreach (Room room in listOfRooms)
                {
                    if (room.forUse == true)
                    {
                        roomsForUse.Add(room);
           
                    }

                }

            foreach (Room room in roomsForUse)
            {
                bool available = true;

                foreach (DoctorUser doctor in listOfDoctors)
                {
                    if (doctor.ordination.Equals(room.TypeOfRoom))
                    {
                        available = false;
                       
                    }
                }

                if (available)
                {
                    availableOrdinations.Add(room);
                }

            }
            return availableOrdinations;

        }

        public void removeScheduledOperationsForDoctor(DoctorUser doctor)
        {
            List<Operation> listOfOperations = operationRepository.GetAll();
                
            foreach(Operation operation in listOfOperations)
            {
                if (operation.Responsable.ID.ToString().Equals(doctor.ID.ToString()))
                {
                    listOfOperations.Remove(operation);
                }
            }
        }
        public void removeScheduledAppointmentForDoctor(DoctorUser doctor)
        {
            List<DoctorAppointment> listOfAppoinments = appointmentRepository.GetAll();

            foreach (DoctorAppointment appointment in listOfAppoinments)
            {
                if (appointment.doctor.ID.ToString().Equals(doctor.ID.ToString()))
                {
                    listOfAppoinments.Remove(appointment);
                }
            }
        }

        public void removeDoctorFromSchedule(DoctorUser doctor)
        {
            List<Schedule> listOfSchedule = new List<Schedule>();
            listOfSchedule = employeesScheduleRepository.GetAll();
            List<DoctorUser> listOfDoctors = doctorRepository.GetAll();
            
          
            foreach (DoctorUser doctorUser in listOfDoctors)
            {
                if (doctorUser.ID.ToString().Equals(doctor.ID.ToString()))
                {
                    foreach (Schedule schedule in listOfSchedule)
                    {
                        if (schedule.employeeID.Equals(doctorUser.ID.ToString()))
                        {
                            employeesScheduleRepository.Delete(schedule.ID);
                            removeScheduledOperationsForDoctor(doctor);
                            removeScheduledAppointmentForDoctor(doctor);
                        }
                    }
                   
                }
            }

        }


        public bool doesDoctorHaveAnAppointmentAtSpecificPeriod(DoctorUser doctor, TimeSpan start, TimeSpan end, string dateToString)
        {
            bool zauzet = false;
            
            List<DoctorAppointment> listaPregleda = appointmentRepository.GetAll();
            foreach (DoctorAppointment dd in listaPregleda)
            {
                DoctorUser dr = dd.doctor;
                if (dr.ID == doctor.ID)
                {
                    if (dd.Date.Equals(dateToString))
                    {
                        TimeSpan time1 = TimeSpan.FromMinutes(15);
                        TimeSpan krajPr = dd.Time.Add(time1);
                        int result = TimeSpan.Compare(start, dd.Time);
                        int result1 = TimeSpan.Compare(start, krajPr);
                        if ((result == 1 && result1 == -1) || result == 0)
                        {
                            zauzet = true;
                        }
                        int rezultat = TimeSpan.Compare(end, dd.Time);
                        int rezultat1 = TimeSpan.Compare(end, krajPr);
                        if ((rezultat == 1 && rezultat1 == -1) || rezultat == 0)
                        {

                            zauzet = true;
                        }
                    }


                }

            }
            return zauzet;
        }

       public bool doesDoctorHaveAnOperationAtSpecificPeriod(DoctorUser doctor, TimeSpan start, TimeSpan end, string date)
        {
            bool zauzet = false;
            
            List<Operation> listOfOperation = operationRepository.GetAll();
            foreach (Operation dd in listOfOperation)
            {
                DoctorUser dr = dd.Responsable;
                if (dr.ID == doctor.ID)
                {
                    if (dd.Date.Equals(date))
                    {
                        int result = TimeSpan.Compare(start, dd.Start);
                        int result1 = TimeSpan.Compare(start, dd.End);
                        if ((result == 1 && result1 == -1) || result == 0)
                        {

                        
                            zauzet = true;
                        }
                        int rezultat = TimeSpan.Compare(end, dd.Start);
                        int rezultat1 = TimeSpan.Compare(end, dd.End);
                        if ((rezultat == 1 && rezultat1 == -1) || rezultat == 0)
                        {

                           
                            zauzet = true;
                        }
                    }




                }
            }
            return zauzet;


        }
            
    
        public Boolean doesDoctorHaveAnAppointmentAtSpecificTime(DoctorUser doctor, TimeSpan time, string date)
        {
            
            List<DoctorAppointment> listOfAppointments = appointmentRepository.GetAll();
            if (listOfAppointments == null)
            {
                listOfAppointments = new List<DoctorAppointment>();
            }
            foreach (DoctorAppointment appointment in listOfAppointments)
            {

                DoctorUser doktorOnAppointment = appointment.doctor;

                if (doktorOnAppointment.ID == doctor.ID)
                {

                    if (appointment.Date.Equals(date))
                    {
                        TimeSpan time1 = TimeSpan.FromMinutes(15);
                        TimeSpan krajPr = appointment.Time.Add(time1);
                        int result = TimeSpan.Compare(time, appointment.Time);
                        int result1 = TimeSpan.Compare(time, krajPr);
                        if ((result == 1 && result1 == -1) || result == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        public Boolean doesDoctorHaveAnOperationAtSpecificTime(DoctorUser doctor, TimeSpan time, string date)
        {
            int result1 = 0;
            int result2 = 0;
            List<Operation> listOfOperation = operationRepository.GetAll();
            if (listOfOperation == null)
            {
                listOfOperation = new List<Operation>();
            }
            foreach (Operation operation in listOfOperation)
            {
                DoctorUser doctorOnOperation = operation.Responsable;
                if (doctorOnOperation.ID == doctor.ID)
                {
                    if (operation.Date.Equals(date))
                    {
                        result1 = TimeSpan.Compare(operation.Start, time);
                        result2 = TimeSpan.Compare(time, operation.End);

                        if ((result1 == -1 && result2 == -1) || result1 == 0)
                        {
                            return true;
                        }

                    }
                }

            }
            return false;
        }

       
    }
}