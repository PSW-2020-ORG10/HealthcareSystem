using System;
using System.Collections.Generic;
using System.Text;

namespace SearchMicroserviceApi.Dtos
{
    public class PrescriptionSearchDto
    {
        public string Medicines { get; set; }
        public string IsUsed { get; set; }
        public string Comment { get; set; }
        public string Doctor { get; set; }

        public PrescriptionSearchDto() { }

        public PrescriptionSearchDto(string medicines, string isUsed, string comment, string doctor)
        {
            Medicines = medicines;
            IsUsed = isUsed;
            Comment = comment;
            Doctor = doctor;
        }
    }
}
