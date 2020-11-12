using System.Collections.Generic;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Contoller
{
    public interface IController<T> where T : Entity
    {
         List<T> GetAll();

         void New(T entity);

         void Update(T entity);

        T GetByid(int id);

        void Remove(T entity);
       
    }
}
