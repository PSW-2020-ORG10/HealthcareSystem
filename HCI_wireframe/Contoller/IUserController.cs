using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Contoller
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
