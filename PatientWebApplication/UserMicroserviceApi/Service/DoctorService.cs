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
            if (isDataValid(doctor.email, doctor.uniqueCitizensidentityNumber, doctor) && isCityValid(doctor.city))
            {
                _doctorRepository.New(doctor);
                return true;
            }
            return false;
        }

        public override bool Update(DoctorUser doctor)
        {
            if (isDataValid(doctor.email, doctor.uniqueCitizensidentityNumber, doctor) && isCityValid(doctor.city))
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
            _doctorRepository.Delete(doctor.id);
        }

        private bool isListOfDoctorsEmpty(List<DoctorUser> listOfObjects)
        {
            if (listOfObjects.Count == 0) return true;
            return false;
        }

        private bool isDoctorsEquals(DoctorUser firstDoctor, DoctorUser secondDoctor)
        {
            if (firstDoctor.id.ToString().Equals(secondDoctor.id.ToString())) return true;
            return false;
        }

        public bool areDatesEqual(string firstDate, string secondDate)
        {
            if (firstDate.Equals(secondDate)) return true;
            return false;
        }

        /// <summary> This method is getting all doctors that have same specialty given as parameter. </summary>
        /// <returns> list of all doctors that have same specialty. </returns>
        public List<DoctorUser> GetDoctorsBySpecialty(string specialty)
        {
            return GetAll().FindAll(doctor => UtilityMethods.CheckForSpecialty(doctor, specialty));
        }
    }
}