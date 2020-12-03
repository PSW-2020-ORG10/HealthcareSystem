/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Luna
 * Purpose: Definition of the Class Doctor.Doctor
 ***********************************************************************/

using HealthClinic.CL.Contoller;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Service
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
            doctorRepository = new DoctorRepository();          
            operationRepository = new OperationRepository();
            appointmentRepository = new AppointmentRepository();
            employeesScheduleRepository = new EmployeesScheduleRepository();

        }
        public override List<DoctorUser> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public override Boolean New(DoctorUser doctor)
        {
            if (isDataValid(doctor.email, doctor.uniqueCitizensidentityNumber, doctor) && isCityValid(doctor.city))
            {
                doctorRepository.New(doctor);
                return true;
            }
            return false;
        }

        public override Boolean Update(DoctorUser doctor)
        {
            if (isDataValid(doctor.email, doctor.uniqueCitizensidentityNumber, doctor) && isCityValid(doctor.city))
            {
                doctorRepository.Update(doctor);
                return true;
            }
            return false;
        }

        public override DoctorUser GetByid(int id)
        {
            return doctorRepository.GetByid(id);
        }

        public override void Remove(DoctorUser doctor)
        {
            doctorRepository.Delete(doctor.id);
            removeDoctorFromSchedule(doctor);
        }

        private List<Room> getRoomsForUse()
        {
            RoomController roomController = new RoomController();
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomController.GetAll();

            return listOfRooms.Where(room => (room.forUse)).ToList();
        }

        private bool isListOfDoctorsEmpty(List<DoctorUser> listOfObjects)
        {
            if (listOfObjects.Count == 0) return true;
            return false;
        }

        private bool isOrdinationAvailable(Room room)
        {
            DoctorController doctorController = new DoctorController();
            List<DoctorUser> listOfDoctors = doctorController.GetAll();

            List<DoctorUser> doctorsWithFreeOrdination = listOfDoctors.Where(doctor => (doctor.ordination.Equals(room.typeOfRoom))).ToList();
            return isListOfDoctorsEmpty(doctorsWithFreeOrdination);
        }

        public List<Room> getAvailableOrdinations()
        {
            List<Room> roomsForUse = new List<Room>();
            roomsForUse = getRoomsForUse();

            return roomsForUse.Where(room => (isOrdinationAvailable(room))).ToList();

        }

        private bool isDoctorResposableForOperation(DoctorUser doctor, Operation operation)
        {
            if (operation.Doctor.id.ToString().Equals(doctor.id.ToString())) return true;
            return false;
        }

        private bool isDoctorResposableForAppointment(DoctorUser doctor, DoctorAppointment appointment)
        {
            if (appointment.Doctor.id.ToString().Equals(doctor.id.ToString())) return true;
            return false;
        }

        public void removeScheduledOperationsForDoctor(DoctorUser doctor)
        {
            List<Operation> listOfOperations = operationRepository.GetAll();

            foreach (Operation operation in listOfOperations)
            {
                if (isDoctorResposableForOperation(doctor, operation))  listOfOperations.Remove(operation);
            }
        }
        public void removeScheduledAppointmentForDoctor(DoctorUser doctor)
        {
            List<DoctorAppointment> listOfAppoinments = appointmentRepository.GetAll();

            foreach (DoctorAppointment appointment in listOfAppoinments)
            {
                if (isDoctorResposableForAppointment(doctor, appointment))  listOfAppoinments.Remove(appointment);
            }
        }

        private void findAndRemoveDoctorFromSchedule(DoctorUser doctor, DoctorUser doctorUser)
        {
            List<Schedule> listOfSchedule = new List<Schedule>();
            listOfSchedule = employeesScheduleRepository.GetAll();

            foreach (Schedule schedule in listOfSchedule)
            {
                if (schedule.EmployeeId.Equals(doctorUser.id.ToString()))  removeDoctorFromRepositories(schedule.id, doctor);
            }
        }


        private void removeDoctorFromRepositories(int id, DoctorUser doctor)
        {
            employeesScheduleRepository.Delete(id);
            removeScheduledOperationsForDoctor(doctor);
            removeScheduledAppointmentForDoctor(doctor);
        }

        private bool isDoctorsEquals(DoctorUser firstDoctor, DoctorUser secondDoctor)
        {
            if (firstDoctor.id.ToString().Equals(secondDoctor.id.ToString())) return true;
            return false;
        }

        public void removeDoctorFromSchedule(DoctorUser doctor)
        {
            List<DoctorUser> listOfDoctors = doctorRepository.GetAll();

            foreach (DoctorUser doctorUser in listOfDoctors)
            {
                if (isDoctorsEquals(doctorUser, doctor)) findAndRemoveDoctorFromSchedule(doctor, doctorUser);
            }

        }
        public bool checkIfDoctorIsBusyForAppointment(DoctorAppointment appointment, TimeSpan selectedTime)
        {
            TimeSpan durationOfAppointment = TimeSpan.FromMinutes(15);
            TimeSpan scheduledEndTime = appointment.Start.Add(durationOfAppointment);

            int areSelectedAndAppointmentTimeEqual = TimeSpan.Compare(selectedTime, appointment.Start);
            int areSelectedAndScheduledEndTimeEqual = TimeSpan.Compare(selectedTime, scheduledEndTime);
            if ((areSelectedAndAppointmentTimeEqual == 1 && areSelectedAndScheduledEndTimeEqual == -1) || areSelectedAndAppointmentTimeEqual == 0) return true;
            return false;
        }

        public Boolean doesDoctorHaveAnAppointmentAtSpecificTime(DoctorUser doctor, TimeSpan time, string date)
        {
            List<DoctorAppointment> listOfAppointments = appointmentRepository.GetAll();
            if (listOfAppointments == null) listOfAppointments = new List<DoctorAppointment>();

            foreach (DoctorAppointment appointment in listOfAppointments)
            {
                if (isDoctorsEquals(appointment.Doctor, doctor) && areDatesEqual(appointment.Date, date) && checkIfDoctorIsBusyForAppointment(appointment, time)) return true;
            }
            return false;
        }

        public bool doesDoctorHaveAnAppointmentAtSpecificPeriod(DoctorUser doctor, TimeSpan start, TimeSpan end, string date)
        {
            List<DoctorAppointment> listOfAppoinments = appointmentRepository.GetAll();
            foreach (DoctorAppointment appointment in listOfAppoinments)
            {
                if (isDoctorsEquals(appointment.Doctor,doctor) && areDatesEqual(appointment.Date, date) && 
                    (checkIfDoctorIsBusyForAppointment(appointment, start) || checkIfDoctorIsBusyForAppointment(appointment, end))) return true;
                
            }
            return false;

        }

        public bool areDatesEqual(String firstDate,String secondDate)
        {
            if (firstDate.Equals(secondDate)) return true;
            return false;
        }

        public bool checkIfDoctorIsBusyForOperation(Operation operation, TimeSpan selectedTime)
        {
            int areSelectedTimeAndOperationStartTimeEqual = TimeSpan.Compare(selectedTime, operation.Start);
            int areSelectedTimeAndOperationEndTimeEqual = TimeSpan.Compare(selectedTime, operation.end);
            if ((areSelectedTimeAndOperationStartTimeEqual == 1 && areSelectedTimeAndOperationEndTimeEqual == -1) || areSelectedTimeAndOperationStartTimeEqual == 0) return true;
            return false;
        }

        public Boolean doesDoctorHaveAnOperationAtSpecificTime(DoctorUser doctor, TimeSpan time, string date)
        {
            List<Operation> listOfOperation = operationRepository.GetAll();
            if (listOfOperation == null) listOfOperation = new List<Operation>();
            foreach (Operation operation in listOfOperation)
            {
                DoctorUser doctorOnOperation = operation.Doctor;
                if (isDoctorsEquals(doctorOnOperation, doctor) && areDatesEqual(operation.Date,date) && checkIfDoctorIsBusyForOperation(operation, time))
                {
                    return true; 
                }
            }
            return false;
        }

        public bool doesDoctorHaveAnOperationAtSpecificPeriod(DoctorUser doctor, TimeSpan start, TimeSpan end, string date)
        {
            List<Operation> listOfOperation = operationRepository.GetAll();
            foreach (Operation operation in listOfOperation)
            {
                DoctorUser doctorOnOperation = operation.Doctor;
                if (isDoctorsEquals(doctorOnOperation, doctor) && areDatesEqual(operation.Date, date) && (checkIfDoctorIsBusyForOperation(operation, start) || checkIfDoctorIsBusyForOperation(operation, end)))
                    return true;
                }
            return false;
        }


    }
}