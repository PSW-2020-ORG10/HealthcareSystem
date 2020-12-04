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

        public string DateAction { get; set; }

        public Message() : base()
        {
        }

        public Message(int id, string text, DateTime timestamp, bool isremoved, string pharmacyname, string dateaction) : base(id)
        {
            this.Text = text;
            this.TimeStamp = timestamp;
            this.IsRemoved = isremoved;
            this.PharmacyName = pharmacyname;
            this.DateAction = dateaction;
        }

        public Message(string text, DateTime timestamp, bool isremoved, string pharmacyname, string dateaction)
        {
            this.Text = text;
            this.TimeStamp = timestamp;
            this.IsRemoved = isremoved;
            this.PharmacyName = pharmacyname;
            this.DateAction = dateaction;
        }

        public override string ToString()
        {
            return this.Text + " sent at " + this.TimeStamp.ToString();
        }
    }
}