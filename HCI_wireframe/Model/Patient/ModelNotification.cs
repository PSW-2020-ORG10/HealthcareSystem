using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Patient
{
    public class ModelNotification : Entity
    {
        public string Data { get; set; }
        public int PatientUserId { get; set; }
        public virtual PatientUser PatientUser { get; set; }

        public ModelNotification(int id, string data, PatientUser patient) : base(id)
        {
            Data = data;
            PatientUserId = patient.id;
            PatientUser = patient;
        }

        public ModelNotification(int id, string data, int patientId) : base(id)
        {
            Data = data;
            PatientUserId = patientId;
        }

        public ModelNotification(int id, string data) : base(id)
        {
            Data = data;
        }

        public ModelNotification(string data)
        {
            Data = data;
        }

        public ModelNotification() : base()
        {

        }
    }
}
