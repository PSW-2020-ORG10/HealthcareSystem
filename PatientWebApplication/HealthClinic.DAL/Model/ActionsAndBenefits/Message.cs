using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Model.ActionsAndBenefits
{
    public class Message: Entity
    {
        public string Text { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsRemoved  {get; set; }

        public string PharmacyName { get; set; }

        public Message() : base()
        {
        }

        public Message(int id, string text, DateTime timestamp, bool isremoved, string pharmacyname) : base(id)
        {
            Text = text;
            Timestamp = timestamp;
            IsRemoved = isremoved;
            PharmacyName = pharmacyname;
        }

        public Message( string text, DateTime timestamp, bool isremoved, string pharmacyname) 
        {
            Text = text;
            Timestamp = timestamp;
            IsRemoved = isremoved;
            PharmacyName = pharmacyname;
        }

        public override string ToString()
        {
            return Text + " sent at " + Timestamp.ToString();
        }
    }
}
