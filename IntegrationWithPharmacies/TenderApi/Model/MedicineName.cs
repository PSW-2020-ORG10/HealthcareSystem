using System;

namespace TenderApi.Model
{
    public class MedicineName
    {
        public String Name { get; set; }
        public String Api { get; set; }

        public MedicineName(String name, String api)
        {
            Name = name;
            Api = api;
        }
        public MedicineName() { }


    }
}
