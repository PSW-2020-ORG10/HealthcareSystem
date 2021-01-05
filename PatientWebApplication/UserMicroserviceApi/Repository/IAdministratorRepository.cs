using System.Collections.Generic;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public interface IAdministratorRepository
    {
        void Delete(int id);
        List<Administrator> GetAll();
        Administrator GetByid(int id);
        void New(Administrator admin);
        void Update(Administrator admin);
        Administrator GetByEmail(string email);
    }
}