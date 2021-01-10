using System.Collections.Generic;
using SearchMicroserviceApi.Model;

namespace SearchMicroserviceApi.Service
{
    public interface IService<T> where T : Entity
    {
        List<T> GetAll();

        void New(T entity);

        void Update(T entity);

        T GetByid(int id);

        void Remove(T entity);
    }
}
