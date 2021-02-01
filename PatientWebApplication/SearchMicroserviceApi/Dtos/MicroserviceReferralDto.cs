using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Dtos
{
    public class MicroserviceReferralDto : Entity
    {
        public string Diagnosis { get; set; }
        public string Procedure { get; set; }
        public int AppointmentId { get; set; }

        public MicroserviceReferralDto() : base() { }
        public MicroserviceReferralDto(int id, string diagnosis, string procedure) : base(id)

        {
            Diagnosis = diagnosis;
            Procedure = procedure;
        }

        public MicroserviceReferralDto(int id, string diagnosis, string procedure, int appointmentId) : base(id)

        {
            Diagnosis = diagnosis;
            Procedure = procedure;
            AppointmentId = appointmentId;
        }
    }
}
