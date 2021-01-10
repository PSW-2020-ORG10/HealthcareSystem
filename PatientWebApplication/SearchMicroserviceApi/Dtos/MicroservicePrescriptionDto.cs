using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Dtos
{
    public class MicroservicePrescriptionDto : Prescription
    {
        public MicroserviceDoctorDto Doctor { get; set; }

        public MicroservicePrescriptionDto(MicroserviceDoctorDto doctor, int id, int patientsid, List<Medicine> medicines, bool isUsed, string comment, int doctorId) : base(id, patientsid, medicines, isUsed, comment, doctorId)
        {
            Doctor = doctor;
        }
    }
}
