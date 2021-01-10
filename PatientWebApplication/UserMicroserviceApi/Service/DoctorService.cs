/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Luna
 * Purpose: Definition of the Class Doctor.Doctor
 ***********************************************************************/

using System.Collections.Generic;
using System.Linq;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Utility;

namespace UserMicroserviceApi.Service
{
    public class DoctorService : AbstractUserService<DoctorUser>
    {
        private IDoctorRepository _doctorRepository;
        private IEmployeesScheduleRepository _employeesScheduleRepository;

        public DoctorService(IEmployeesScheduleRepository employeesScheduleRepository, IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
            _employeesScheduleRepository = employeesScheduleRepository;
        }

        public DoctorService(MyDbContext context)
        {
            _doctorRepository = new DoctorRepository(context);
            _employeesScheduleRepository = new EmployeesScheduleRepository(context);
        }

        public override List<DoctorUser> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public override bool New(DoctorUser doctor)
        {
            if (IsDataValid(doctor.Email, doctor.UniqueCitizensidentityNumber, doctor) && IsCityValid(doctor.City))
            {
                _doctorRepository.New(doctor);
                return true;
            }
            return false;
        }

        public override bool Update(DoctorUser doctor)
        {
            if (IsDataValid(doctor.Email, doctor.UniqueCitizensidentityNumber, doctor) && IsCityValid(doctor.City))
            {
                _doctorRepository.Update(doctor);
                return true;
            }
            return false;
        }

        public override DoctorUser GetByid(int id)
        {
            return _doctorRepository.GetByid(id);
        }

        public override void Remove(DoctorUser doctor)
        {
            _doctorRepository.Delete(doctor.Id);
        }

        private bool IsListOfDoctorsEmpty(List<DoctorUser> listOfObjects)
        {
            return listOfObjects.Count == 0;
        }

        private bool IsDoctorsEquals(DoctorUser firstDoctor, DoctorUser secondDoctor)
        {
            return firstDoctor.Id.ToString().Equals(secondDoctor.Id.ToString());
        }

        public bool AreDatesEqual(string firstDate, string secondDate)
        {
            return firstDate.Equals(secondDate);
        }

        /// <summary> This method is getting all doctors that have same specialty given as parameter. </summary>
        /// <returns> list of all doctors that have same specialty. </returns>
        public List<DoctorUser> GetDoctorsBySpecialty(string specialty)
        {
            return GetAll().FindAll(doctor => UtilityMethods.CheckForSpecialty(doctor, specialty));
        }
    }
}