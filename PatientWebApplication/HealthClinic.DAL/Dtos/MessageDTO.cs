using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class MessageDTO
    {
        public string Text { get; set; }

        public DateTime Timestamp { get; set; }

        public string PharmacyName { get; set; }

        public MessageDTO( string text, DateTime timestamp, string pharmacyname)
        {
            Text = text;
            Timestamp = timestamp;
            PharmacyName = pharmacyname;
        }

        public MessageDTO()
        {
        }

        public override string ToString()
        {
            return Text + " sent at " + Timestamp.ToString();
        }
    }
}
