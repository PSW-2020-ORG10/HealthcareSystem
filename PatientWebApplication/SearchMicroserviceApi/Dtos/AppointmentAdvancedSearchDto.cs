using System;
using System.Collections.Generic;
using System.Text;

namespace SearchMicroserviceApi.Dtos
{
    public class AppointmentAdvancedSearchDto
    {
        public string FirstRole { get; set; }
        public string First { get; set; }
        public string[] RestRoles { get; set; }
        public string[] Rest { get; set; }
        public string[] LogicOperators { get; set; }
        public int PatientId { get; set; }

        public AppointmentAdvancedSearchDto() { }

        public AppointmentAdvancedSearchDto(string firstRole, string first, string[] restRoles, string[] rest, string[] logicOperators, int id)
        {
            FirstRole = firstRole;
            First = first;
            RestRoles = restRoles;
            Rest = rest;
            LogicOperators = logicOperators;
            PatientId = id;
        }

    }
}
