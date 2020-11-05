using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Patient
{
    public class ModelNotification : StringData
    { 
        public int PatientUserId { get; set; }
        public virtual PatientUser PatientUser { get; set; }

        public ModelNotification(int id, string data, PatientUser patient) : base(id, data)
        {
            Data = data;
            PatientUserId = patient.id;
            PatientUser = patient;
        }

        public ModelNotification(int id, string data, int patientId) : base(id, data)
        {
            Data = data;
            PatientUserId = patientId;
        }

        public ModelNotification(int id, string data) : base(id, data)
        {
            Data = data;
        }

        public ModelNotification(string data) : base(data)
        {

        }

        public ModelNotification() : base()
        {

        }
    }
}
