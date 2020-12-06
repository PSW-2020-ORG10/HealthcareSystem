using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public class Medicine2
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String UnwantedReactions { get; set; }

        public Medicine2(int id, String name, String description, String unwantedReactions)
        {
            Id = id; ;
            Name = name;
            Description = description;
            UnwantedReactions = unwantedReactions;
        }
        public Medicine2()
        {
        }
        public override string ToString()
        {
            return this.Name + "; " + this.Description;
        }
    }
}
