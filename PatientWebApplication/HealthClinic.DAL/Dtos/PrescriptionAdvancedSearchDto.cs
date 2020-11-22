using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class PrescriptionAdvancedSearchDto
    {
        public String FirstRole { get; set; }
        public String First { get; set; }
        public String[] RestRoles { get; set; }
        public String[] Rest { get; set; }
        public String[] LogicOperators { get; set; }

        public PrescriptionAdvancedSearchDto() { }

        public PrescriptionAdvancedSearchDto(string firstRole, string first, string[] restRoles, string[] rest, string[] logicOperators)
        {
            FirstRole = firstRole;
            First = first;
            RestRoles = restRoles;
            Rest = rest;
            LogicOperators = logicOperators;
        }

    }
}
