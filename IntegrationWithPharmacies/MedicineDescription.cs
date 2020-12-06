using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public class MedicineDescription
    {
        public String Description { get; set; }
      
        public MedicineDescription(String description)
        {
            Description = description;
        }
        public MedicineDescription()
        {
        }
        public override string ToString()
        {
            return this.Description;
        }
    }
}
