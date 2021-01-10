/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public class SecretaryService : AbstractUserService<SecretaryUser>
    {
        public EmployeesScheduleRepository employeesScheduleRepository;
        public SecretaryRepository secretaryRepository;

        public SecretaryService()
        {
            secretaryRepository = new SecretaryRepository();
            employeesScheduleRepository = new EmployeesScheduleRepository();
        }

        public override List<SecretaryUser> GetAll()
        {
            return secretaryRepository.GetAll();
        }

        public override bool New(SecretaryUser secretary)
        {
            if (IsDataValid(secretary.Email, secretary.UniqueCitizensidentityNumber, secretary) && IsCityValid(secretary.City))
            {
                secretaryRepository.New(secretary);
                return true;
            }
            return false;
        }

        public override bool Update(SecretaryUser secretary)
        {
            if (IsDataValid(secretary.Email, secretary.UniqueCitizensidentityNumber, secretary) && IsCityValid(secretary.City))
            {
                secretaryRepository.Update(secretary);
                return true;
            }
            return false;
        }

        public override SecretaryUser GetByid(int id)
        {
            return secretaryRepository.GetByid(id);
        }

        public override void Remove(SecretaryUser secretary)
        {
            RemoveSecretaryFromSchedule(secretary);
            secretaryRepository.Delete(secretary.Id);
        }


        private bool IsScheduleForSecretary(Schedule schedule, SecretaryUser secretaryUser)
        {
            return schedule.Employee.FirstName.Equals(secretaryUser.FirstName);
        }

        private void FindAndDeleteScheduleForSecretary(SecretaryUser secretaryUser)
        {
            List<Schedule> listOfSchedule = new List<Schedule>();
            listOfSchedule = employeesScheduleRepository.GetAll();

            foreach (Schedule schedule in listOfSchedule)
            {
                if (IsScheduleForSecretary(schedule, secretaryUser)) employeesScheduleRepository.Delete(schedule.Id);
            }
        }

        private bool AreSecreatariesEqualByid(SecretaryUser firstSecretary, SecretaryUser secondSecretary)
        {
            return firstSecretary.Id.ToString().Equals(secondSecretary.Id.ToString());
        }

        public void RemoveSecretaryFromSchedule(SecretaryUser secretary)
        {
            foreach (SecretaryUser secretaryUser in secretaryRepository.GetAll())
            {
                if (AreSecreatariesEqualByid(secretaryUser, secretary)) FindAndDeleteScheduleForSecretary(secretaryUser);
            }
        }
    }
}