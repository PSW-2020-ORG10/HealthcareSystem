using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_diagram.Repository;
using HealthClinic.BL.Model.Hospital;

namespace HealthClinic.BL.Repository
{
    class RequestMedicineRepository : GenericFileRepository<Medicine>
    {
        public RequestMedicineRepository(string filePath) : base(filePath) { }

        public RequestMedicineRepository() :  base() { }
       
    }
}