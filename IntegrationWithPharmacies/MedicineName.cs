using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public class MedicineName
    {
        public String Name { get; set; }

        public MedicineName(String name)
        {
            Name = name;
        }
        public MedicineName() { }

        public override string ToString()
        {
            return Name;
        }
        public String GetMedicineName()
        {
            return Name;
        }

    }
}