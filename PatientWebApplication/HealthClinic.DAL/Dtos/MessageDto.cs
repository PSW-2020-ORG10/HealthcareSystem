using System;

namespace HealthClinic.CL.Dtos
{
    public class MessageDto
    {
        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

        public string PharmacyName { get; set; }

        public MessageDto(string text, DateTime timestamp, string pharmacyname)
        {
            Text = text;
            TimeStamp = timestamp;
            PharmacyName = pharmacyname;
        }

        public MessageDto()
        {
        }

        public override string ToString()
        {
            return Text + " sent at " + TimeStamp.ToString();
        }
    }
}