/***********************************************************************
 * Module:  SecretaryRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.SecretaryRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Secretary;

namespace HealthClinic.CL.Repository
{
    public class SecretaryRepository : GenericFileRepository<SecretaryUser>
   {
        public SecretaryRepository(string filePath) : base(filePath) { }

        public SecretaryRepository() : base() { }

    }
}