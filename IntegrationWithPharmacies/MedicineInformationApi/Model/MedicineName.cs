using System;

namespace MedicineInformationApi.Model
{
    public class MedicineName
    {
        public String Name { get; set; }
        public String Api { get; set; }

        public MedicineName(String name)
        {
            Name = name;
            Api = "";
        }
        public MedicineName() { }


    }
}
