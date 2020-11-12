using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Contoller
{
    public interface IUserController<T> where T : Entity
    {
        List<T> GetAll();

        Boolean New(T entity);

        Boolean Update(T entity);

        T GetByid(int id);

        void Remove(T entity);

    }
}
