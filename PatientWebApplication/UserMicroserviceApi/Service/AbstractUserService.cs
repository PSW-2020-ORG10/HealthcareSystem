using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Model.Manager;
using HealthClinic.CL.Model.Secretary;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public abstract class AbstractUserService<T> where T : Entity
    {
        public abstract List<T> GetAll();

        public abstract bool New(T entity);

        public abstract bool Update(T entity);

        public abstract T GetByid(int id);

        public abstract void Remove(T entity);

        public bool isCityValid(string city)
        {
            return Regex.Match(city, "^([A-Z][a-zA-Z\\s*]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+[\\s*][0-9]+[a-z]*[,][\\s*]*[0-9]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+)$").Success;
        }
        public bool isDataValid(string email, string ucin, T user)
        {

            bool foundWithinDoctors = isFoundInDoctors(email, ucin, user);
            bool foundWithinSecretaries = isFoundInSecretaries(email, ucin, user);
            bool foundWithinManagers = isFoundInManagers(email, ucin, user);
            if (!foundWithinDoctors || !foundWithinSecretaries || !foundWithinManagers) return false;
            return true;
        }

        private bool areUCINsEqual(string firstUCIN, string secondUCIN)
        {
            if (firstUCIN.Equals(secondUCIN)) return true;
            return false;
        }

        private bool areIDsEqual(int firstID, int secondID)
        {
            if (firstID == secondID) return true;
            return false;
        }

        private bool areEmailsEqual(string firstEmail, string secondEmail)
        {
            if (firstEmail.Equals(secondEmail)) return true;
            return false;
        }

        public bool isFoundInManagers(string email, string ucin, T user)
        {
            string path = bingPathToAppDir(@"JsonFiles\manager.json");
            ManagerRepository managerRepository = new ManagerRepository(path);
            List<ManagerUser> listOfManagers = managerRepository.GetAll();

            foreach (ManagerUser manager in listOfManagers)
            {
                if (!areIDsEqual(manager.id, user.id) && (areUCINsEqual(manager.uniqueCitizensidentityNumber, ucin) || areEmailsEqual(manager.email, email)))
                {
                    return false;
                }
            }

            return true;


        }

        public bool isFoundInSecretaries(string email, string ucin, T user)
        {
            string path = bingPathToAppDir(@"JsonFiles\secretary.json");
            SecretaryRepository secretaryRepository = new SecretaryRepository(path);
            List<SecretaryUser> listOfSecretaries = secretaryRepository.GetAll();

            foreach (SecretaryUser secretary in listOfSecretaries)
            {
                if (!areIDsEqual(secretary.id, user.id) && (areUCINsEqual(secretary.uniqueCitizensidentityNumber, ucin) || areEmailsEqual(secretary.email, email)))
                {
                    return false;
                }
            }

            return true;
        }

        public bool isFoundInDoctors(string email, string ucin, T user)
        {
            string path = bingPathToAppDir(@"JsonFiles\doctors.json");
            DoctorRepository doctorRepository = new DoctorRepository();
            List<DoctorUser> listOfDoctors = doctorRepository.GetAll();

            foreach (DoctorUser doctor in listOfDoctors)
            {
                if (!areIDsEqual(doctor.id, user.id) && (areUCINsEqual(doctor.uniqueCitizensidentityNumber, ucin) || areEmailsEqual(doctor.email, email)))
                {
                    return false;
                }
            }

            return true;
        }



        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
            Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }
    }
}
