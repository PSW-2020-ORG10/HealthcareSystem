using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class EPrescriptionAdapter
    {
        public static EPrescription EPrescriptionDtoToEPresctiption(EPrescriptionDto dto)
        {
            return new EPrescription(dto.Pharmacy, dto.Name, dto.Surname, dto.MedicalIDNumber, dto.Medicine, dto.Quantity, dto.Usage);
        }
    }
}
