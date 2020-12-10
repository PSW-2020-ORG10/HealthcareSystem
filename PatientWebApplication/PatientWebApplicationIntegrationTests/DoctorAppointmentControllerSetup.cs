using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientWebApplicationIntegrationTests
{
    public static class DoctorAppointmentControllerSetup
    {
        public static MyDbContext DbContext { get; set; }

        public static MyDbContext SetupDbContext()
        {
            DoctorUser doctor1 = new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2");
            DoctorUser doctor2 = new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Pulmonology", new List<DoctorNotification>(), "Ordination 2");
            DoctorUser doctor3 = new DoctorUser(3, "TestDoctorName3", "TestDoctorNameSurname3", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2");

            DbContext.Doctors.Add(doctor1);
            DbContext.Doctors.Add(doctor2);
            DbContext.Doctors.Add(doctor3);

            PatientUser patient1 = new PatientUser(1, "PatientName1", "PatientSurname1", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "PatientName2", "PatientSurname2", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            DbContext.Patients.Add(patient1);
            DbContext.Patients.Add(patient2);

            Schedule schedule1 = new Schedule(2, "2", "03/03/2021", true, "EmployeeName1", "EmployeeSurname1", 1, "1");
            Schedule schedule2 = new Schedule(1, "1", "02/02/2021", true, "EmployeeName2", "EmployeeSurname2", 2, "1");
            Schedule schedule3 = new Schedule(3, "3", "02/02/2021", true, "EmployeeName2", "EmployeeSurname2", 3, "1");

            DbContext.Schedules.Add(schedule1);
            DbContext.Schedules.Add(schedule2);
            DbContext.Schedules.Add(schedule3);

            Shift shift1 = new Shift(1, "14:00", "16:00");
            Shift shift2 = new Shift(2, "12:00", "12:30");
            Shift shift3 = new Shift(1, "14:00", "16:00");

            DbContext.Shifts.Add(shift1);
            DbContext.Shifts.Add(shift2);
            DbContext.Shifts.Add(shift3);

            Referral referral1 = new Referral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1);
            Referral referral2 = new Referral(2, "Medicine2", "Take medicine until", 3, "Appointment", "comment", 1);

            DbContext.Referrals.Add(referral1);
            DbContext.Referrals.Add(referral2);

            DoctorAppointment appointment1 = new DoctorAppointment(1, new TimeSpan(0, 14, 15, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(2, new TimeSpan(0, 14, 30, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment3 = new DoctorAppointment(3, new TimeSpan(0, 15, 0, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment4 = new DoctorAppointment(4, new TimeSpan(0, 15, 45, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment5 = new DoctorAppointment(5, new TimeSpan(0, 12, 0, 0, 0), "02/02/2020", new PatientUser(), new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment6 = new DoctorAppointment(6, new TimeSpan(0, 12, 15, 0, 0), "02/02/2020", new PatientUser(), new DoctorUser(3, "TestDoctorName3", "TestDoctorNameSurname3", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");

            DbContext.DoctorAppointments.Add(appointment1);
            DbContext.DoctorAppointments.Add(appointment2);
            DbContext.DoctorAppointments.Add(appointment3);
            DbContext.DoctorAppointments.Add(appointment4);
            DbContext.DoctorAppointments.Add(appointment5);
            DbContext.DoctorAppointments.Add(appointment6);

            OperationReferral operationReferral1 = new OperationReferral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1);
            OperationReferral operationReferral2 = new OperationReferral(2, "Medicine2", "Take medicine until", 3, "Appointment", "comment", 2);

            DbContext.OperationReferrals.Add(operationReferral1);
            DbContext.OperationReferrals.Add(operationReferral2);

            Operation operation1 = new Operation(1, 2, "03/03/2020", new TimeSpan(0, 14, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 1, "room1");
            Operation operation2 = new Operation(2, 1, "03/10/2020", new TimeSpan(0, 15, 0, 0), new TimeSpan(0, 15, 15, 0, 0), 2, "room1");

            DbContext.Operations.Add(operation1);
            DbContext.Operations.Add(operation2);

            DbContext.SaveChanges();
            return DbContext;
        }
    }
}
