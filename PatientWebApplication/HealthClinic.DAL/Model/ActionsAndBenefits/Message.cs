using HealthClinic.CL.Model.Patient;
using System;


namespace HealthClinic.CL.Model.ActionsAndBenefits
{
    public class Message : Entity
    {
        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

        public bool IsRemoved { get; set; }

        public string PharmacyName { get; set; }

        public Message() : base()
        {
        }

        public Message(int id, string text, DateTime timestamp, bool isremoved, string pharmacyname) : base(id)
        {
            Text = text;
            TimeStamp = timestamp;
            IsRemoved = isremoved;
            PharmacyName = pharmacyname;
        }

        public Message(string text, DateTime timestamp, bool isremoved, string pharmacyname)
        {
            Text = text;
            TimeStamp = timestamp;
            IsRemoved = isremoved;
            PharmacyName = pharmacyname;
        }

        public override string ToString()
        {
            return Text + " sent at " + TimeStamp.ToString();
        }
    }
}