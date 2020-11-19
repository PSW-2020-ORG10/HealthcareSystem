using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class PrescriptionUnpackedDto
    {
        public Prescription Prescription { get; set; }
        public PrescriptionSearchDto PrescriptionSearchDto { get; set; }
        public int[] SearchResults { get; set; }

        public PrescriptionUnpackedDto() { }

        public PrescriptionUnpackedDto(Prescription prescription, PrescriptionSearchDto prescriptionSearchDto, int[] searchResults)
        {
            Prescription = prescription;
            PrescriptionSearchDto = prescriptionSearchDto;
            SearchResults = searchResults;
        }
    }
}
