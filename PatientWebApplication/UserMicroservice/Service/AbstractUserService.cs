using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Model.Manager;
using HealthClinic.CL.Model.Secretary;

namespace HealthClinic.CL.Service
{
    public abstract class AbstractUserService<T> where T : Entity
    {
        public abstract List<T> GetAll();

        public abstract Boolean New(T entity);

        public abstract Boolean Update(T entity);

        public abstract T GetByid(int id);

        public abstract void Remove(T entity);

        public Boolean isCityValid(String city)
        {
            return Regex.Match(city, "^([A-Z][a-zA-Z\\s*]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+[\\s*][0-9]+[a-z]*[,][\\s*]*[0-9]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+)$").Success;
        }
        public Boolean isDataValid(String email, String ucin,T user)
        {
           
            Boolean foundWithinDoctors = isFoundInDoctors(email, ucin, user);
            Boolean foundWithinSecretaries = isFoundInSecretaries(email, ucin, user);
            Boolean foundWithinManagers = isFoundInManagers(email, ucin, user);
            if(!foundWithinDoctors || !foundWithinSecretaries || !foundWithinManagers) return false;
            return true;
        }

        private bool areUCINsEqual(String firstUCIN,String secondUCIN)
        {
            if (firstUCIN.Equals(secondUCIN)) return true;
            return false;
        }

        private bool areIDsEqual(int firstID, int secondID)
        {
            if (firstID==secondID) return true;
            return false;
        }

        private bool areEmailsEqual(String firstEmail, String secondEmail)
        {
            if (firstEmail.Equals(secondEmail)) return true;
            return false;
        }

        public bool isFoundInManagers(string email, string ucin, T user)
        {
            String path = bingPathToAppDir(@"JsonFiles\manager.json");
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
            String path = bingPathToAppDir(@"JsonFiles\secretary.json");
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
            String path = bingPathToAppDir(@"JsonFiles\doctors.json");
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
