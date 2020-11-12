using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthClinic.BL.Model.Patient;

namespace HCI_wireframe.Service
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
