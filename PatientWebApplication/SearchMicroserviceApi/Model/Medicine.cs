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
        public List<ModelRoom> Room { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public bool IsConfirmed { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, bool isConfirmed) : base(id, name, quantity, room)
        {
            Description = description;
            Room = room;
            IsConfirmed = isConfirmed;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isConfirmed) : base(id, name, quantity, room)
        {
            DoctorId = doctorId;
            Description = description;
            Room = room;
            IsConfirmed = isConfirmed;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isConfirmed, int prescriptionId) : base(id, name, quantity, room)
        {
            DoctorId = doctorId;
            Description = description;
            Room = room;
            IsConfirmed = isConfirmed;
            PrescriptionId = prescriptionId;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, bool isConfirmed, Prescription prescription) : base(id, name, quantity, room)
        {
            Description = description;
            Room = room;
            IsConfirmed = isConfirmed;
            Prescription = prescription;
            PrescriptionId = prescription.Id;
        }

        public Medicine() : base() { }
    }
}