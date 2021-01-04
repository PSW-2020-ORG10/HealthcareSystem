using System.Collections.Generic;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Service
{
    interface IService<T> where T : Entity
    {
        List<T> GetAll();

        void New(T entity);

        void Update(T entity);

        T GetByid(int id);

        void Remove(T entity);
    }
}
