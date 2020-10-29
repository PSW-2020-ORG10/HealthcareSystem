using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
namespace HCI_wireframe.Repository
{
    class RequestMedicineRepository : GenericFileRepository<Medicine>
    {
        public RequestMedicineRepository(string filePath) : base(filePath) { }

        public RequestMedicineRepository() :  base() { }
       
    }
}