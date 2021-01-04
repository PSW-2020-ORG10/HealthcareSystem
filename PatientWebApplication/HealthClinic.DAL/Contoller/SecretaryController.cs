/***********************************************************************
 * Module:  SecretaryController.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Contoller.SecretaryController
 ***********************************************************************/

using HealthClinic.CL.Model.Secretary;
using HealthClinic.CL.Service;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Contoller
{
    public class SecretaryController : IUserController<SecretaryUser>
    {
        public SecretaryService secretaryService;

        public SecretaryController()
        {
            secretaryService = new SecretaryService();
        }


        public Boolean Update(SecretaryUser secretary)
        {
           return secretaryService.Update(secretary);
        }

        public void Remove(SecretaryUser secretary)
        {
            secretaryService.Remove(secretary);
        }

        public Boolean New(SecretaryUser secretary)
        {
            return secretaryService.New(secretary);
        }

        public List<SecretaryUser> GetAll()
        {
            return secretaryService.GetAll();
        }

        public SecretaryUser GetByid(int id)
        {
            return secretaryService.GetByid(id);
        }
       
    }
}