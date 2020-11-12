using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.BL.Repository
{
    public class PatientsRepository : GenericFileRepository<PatientUser>
    {
        public PatientsRepository(string filePath) : base(filePath) { }

        public PatientsRepository() : base() { }

    }

}

