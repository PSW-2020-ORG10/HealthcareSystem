using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Service;
namespace HCI_wireframe.Contoller
{
    class RequestMedicineController : IController<Medicine>
    {
        public RequestMedicineService medicineService;

        public RequestMedicineController()
        {
            medicineService = new RequestMedicineService();
        }
      
        public void New(Medicine medicine)
        {
           medicineService.New(medicine);
        }
        public void Update(Medicine medicine)
        {
        }
        public void Remove(Medicine medicine)
        {
            medicineService.Remove(medicine);
        }
       
        public List<Medicine> GetAll()
        {
           return medicineService.GetAll();
        }

        public Medicine GetByid(int id)
        {
            return medicineService.GetByid(id);
        }
    }
}