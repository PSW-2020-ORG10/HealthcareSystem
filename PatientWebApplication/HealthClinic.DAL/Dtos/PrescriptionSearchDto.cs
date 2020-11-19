using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class PrescriptionSearchDto
    {
        public String Medicines { get; set; }
        public String IsUsed { get; set; }
        public String Comment { get; set; }
        public PrescriptionSearchDto() { }

        public PrescriptionSearchDto(String medicines, String isUsed, String comment)
        {
            this.Medicines = medicines;
            this.IsUsed = isUsed;
            this.Comment = comment;
        }
    }
}
