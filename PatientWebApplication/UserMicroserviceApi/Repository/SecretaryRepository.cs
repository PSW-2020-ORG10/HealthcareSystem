/***********************************************************************
 * Module:  SecretaryRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.SecretaryRepository
 ***********************************************************************/

using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public class SecretaryRepository : GenericFileRepository<SecretaryUser>
    {
        public SecretaryRepository(string filePath) : base(filePath) { }

        public SecretaryRepository() : base() { }

    }
}