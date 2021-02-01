using AppointmentMicroserviceApi.Model;

namespace AppointmentMicroserviceApi.Doctor
{
    public class OperationReferral : Entity
    {
        public string Diagnosis { get; set; }
        public string Procedure { get; set; }
        public int OperationId { get; set; }

        public OperationReferral() : base() { }
        public OperationReferral(int id, string diagnosis, string procedure) : base(id)

        {
            Diagnosis = diagnosis;
            Procedure = procedure;
        }

        public OperationReferral(int id, string diagnosis, string procedure, int operationId) : base(id)

        {
            Diagnosis = diagnosis;
            Procedure = procedure;
            OperationId = operationId;
        }
    }
}
