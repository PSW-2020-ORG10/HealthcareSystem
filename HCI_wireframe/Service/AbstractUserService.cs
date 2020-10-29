using Class_diagram.Model.Manager;
using Class_diagram.Model.Patient;
using Class_diagram.Model.Secretary;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HCI_wireframe.Service
{
    public abstract class AbstractUserService<T> where T : Entity
    {
        public abstract List<T> GetAll();

        public abstract Boolean New(T entity);

        public abstract Boolean Update(T entity);

        public abstract T GetByID(int ID);

        public abstract void Remove(T entity);

        public Boolean isCityValid(String city)
        {
            return Regex.Match(city, "^([A-Z][a-zA-Z\\s*]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+[\\s*][0-9]+[a-z]*[,][\\s*]*[0-9]+[,][\\s*]*[A-Z][a-zA-Z\\s*]+)$").Success;
        }
        public Boolean isDataValid(String email, String ucin,T user)
        {
            Boolean foundWithinPatients = isFoundInPatients(email, ucin,user);
            Boolean foundWithinDoctors = isFoundInDoctors(email, ucin, user);
            Boolean foundWithinSecretaries = isFoundInSecretaries(email, ucin, user);
            Boolean foundWithinManagers = isFoundInManagers(email, ucin, user);
            if(foundWithinPatients==false || foundWithinDoctors== false || foundWithinSecretaries== false || foundWithinManagers== false)
            {
                return false;
            }
            return true;
        }

        public bool isFoundInManagers(string email, string ucin, T user)
        {
            String path = bingPathToAppDir(@"JsonFiles\manager.json");
            ManagerRepository managerRepository = new ManagerRepository(path);
            List<ManagerUser> listOfManagers = managerRepository.GetAll();

            foreach (ManagerUser manager in listOfManagers)
            {
                if (manager.ID != user.ID)
                {
                    if (manager.UniqueCitizensIdentityNumber.Equals(ucin) || manager.Email.Equals(email))
                    {
                        return false;
                    }
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
            {if (secretary.ID != user.ID)
                {
                    if (secretary.UniqueCitizensIdentityNumber.Equals(ucin) || secretary.Email.Equals(email))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool isFoundInDoctors(string email, string ucin, T user)
        {
            String path = bingPathToAppDir(@"JsonFiles\doctors.json");
            DoctorRepository doctorRepository = new DoctorRepository(path);
            List<DoctorUser> listOfDoctors = doctorRepository.GetAll();

            foreach (DoctorUser doctor in listOfDoctors)
            {
                if(doctor.ID!=user.ID) {
                    if (doctor.UniqueCitizensIdentityNumber.Equals(ucin) || doctor.Email.Equals(email))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Boolean isFoundInPatients(string email, string ucin, T user)
        {
            String path = bingPathToAppDir(@"JsonFiles\patients.json");
            PatientsRepository patientsRepository = new PatientsRepository(path);
            List<PatientUser> listOfPatients = patientsRepository.GetAll();

            foreach (PatientUser patient in listOfPatients)
            {if (patient.ID != user.ID)
                {
                    if (patient.Email.Equals(email) || patient.UniqueCitizensIdentityNumber.Equals(ucin))
                    {
                        return false;
                    }
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
