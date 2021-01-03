/***********************************************************************
 * Module:  Medicine.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Manager.Medicine
 ***********************************************************************/


using System.Collections.Generic;


namespace SearchMicroserviceApi.Model
{
    public class Medicine : Equipment
    {
        public List<ModelRoom> room { get; set; }
        public int doctorId { get; set; }
        public string description { get; set; }
        public bool isConfirmed { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, bool isConfirmed) : base(id, name, quantity, room)
        {
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isConfirmed) : base(id, name, quantity, room)
        {
            this.doctorId = doctorId;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isConfirmed, int prescriptionId) : base(id, name, quantity, room)
        {
            this.doctorId = doctorId;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
            PrescriptionId = prescriptionId;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, bool isConfirmed, Prescription prescription) : base(id, name, quantity, room)
        {
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
            Prescription = prescription;
            PrescriptionId = prescription.id;
        }

        public Medicine() : base()
        {
        }
    }
}