using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Service
{
    public abstract class AbstractUserService<T> where T : Entity
    {
        public abstract List<T> GetAll();
        public abstract bool New(T entity);
        public abstract bool Update(T entity);
        public abstract T GetByid(int id);
        public abstract void Remove(T entity);

        public bool IsCityValid(string city)
        {
            return Regex.Match(city, "^([A-Z][a-zA-Z\\s*]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+[\\s*][0-9]+[a-z]*[,][\\s*]*[0-9]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+)$").Success;
        }

        public bool IsDataValid(string email, string ucin, T user)
        {
            return IsFoundInDoctors(email, ucin, user) && IsFoundInSecretaries(email, ucin, user) && IsFoundInManagers(email, ucin, user);
        }

        private bool AreUCINsEqual(string firstUCIN, string secondUCIN)
        {
            return firstUCIN.Equals(secondUCIN);
        }

        private bool AreIDsEqual(int firstID, int secondID)
        {
            return firstID == secondID;
        }

        private bool AreEmailsEqual(string firstEmail, string secondEmail)
        {
            return firstEmail.Equals(secondEmail);
        }

        public bool IsFoundInManagers(string email, string ucin, T user)
        {
            ManagerRepository managerRepository = new ManagerRepository(BingPathToAppDir(@"JsonFiles\manager.json"));
            foreach (ManagerUser manager in managerRepository.GetAll())
            {
                if (!AreIDsEqual(manager.Id, user.Id) && (AreUCINsEqual(manager.UniqueCitizensidentityNumber, ucin) || AreEmailsEqual(manager.Email, email)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsFoundInSecretaries(string email, string ucin, T user)
        {
            SecretaryRepository secretaryRepository = new SecretaryRepository(BingPathToAppDir(@"JsonFiles\secretary.json"));

            foreach (SecretaryUser secretary in secretaryRepository.GetAll())
            {
                if (!AreIDsEqual(secretary.Id, user.Id) && (AreUCINsEqual(secretary.UniqueCitizensidentityNumber, ucin) || AreEmailsEqual(secretary.Email, email)))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFoundInDoctors(string email, string ucin, T user)
        {
            DoctorRepository doctorRepository = new DoctorRepository();
            foreach (DoctorUser doctor in doctorRepository.GetAll())
            {
                if (!AreIDsEqual(doctor.Id, user.Id) && (AreUCINsEqual(doctor.UniqueCitizensidentityNumber, ucin) || AreEmailsEqual(doctor.Email, email)))
                {
                    return false;
                }
            }

            return true;
        }

        public static string BingPathToAppDir(string localPath)
        {
            return (new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"...." + localPath)))).ToString();
        }
    }
}
