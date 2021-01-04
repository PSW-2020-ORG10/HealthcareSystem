using System;

namespace HealthClinic.CL.Dtos
{
    public class MessageDto
    {
        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

        public string DateStamp { get; set; }

        public string PharmacyName { get; set; }

        public string DateAction { get; set; }

        public MessageDto(string text, string dateStamp, DateTime timeStamp, string pharmacyName, string dateAction)
        {
            Text = text;
            TimeStamp = timeStamp;
            PharmacyName = pharmacyName;
            DateAction = dateAction;
            DateStamp = dateStamp;
        }

        public MessageDto() { }

        public override string ToString()
        {
            return Text + " sent at " + TimeStamp.ToString();
        }
    }
}