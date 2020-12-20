namespace HealthClinic.BL.Model.Patient
{
    public class StringData : Entity
    {
        public string Data { get; set; }

        public StringData(string data)
        {
            Data = data;
        }

        public StringData(int id, string data) : base(id)
        {
            Data = data;
        }

        public StringData()
        {
            Data = "";
        }
    }
}
