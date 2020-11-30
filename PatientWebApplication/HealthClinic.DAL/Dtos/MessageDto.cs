using System;

namespace HealthClinic.CL.Dtos
{
    public class MessageDto
    {
        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

        public string PharmacyName { get; set; }

        public string DateAction { get; set; }

        public MessageDto(string text, DateTime timestamp, string pharmacyname, string dateaction)
        {
            this.Text = text;
            this.TimeStamp = timestamp;
            this.PharmacyName = pharmacyname;
            this.DateAction = dateaction;
        }

        public MessageDto()
        {
        }

        public override string ToString()
        {
            return this.Text + " sent at " + this.TimeStamp.ToString();
        }
    }
}