using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class EPrescriptionService
    {
        public EPrescriptionRepository EPrescriptionRepository { get; }
        public IEPrescriptionRepository IPrescriptionRepository { get; set; }
        public EPrescriptionService() { }

        public EPrescriptionService(MyDbContext context)
        {
            EPrescriptionRepository = new EPrescriptionRepository(context);
        }
        public EPrescriptionService(IEPrescriptionRepository prescriptionRepositoy)
        {
            IPrescriptionRepository = prescriptionRepositoy;
        }
        public List<EPrescription> GetAll()
        {
            return EPrescriptionRepository.GetAll();
        }
        public List<EPrescription> GetAllForStub()
        {
            return IPrescriptionRepository.GetAll();
        }
        public EPrescription Create(EPrescriptionDto dto)
        {
            EPrescription prescription = EPrescriptionAdapter.EPrescriptionDtoToEPresctiption(dto);
            return EPrescriptionRepository.Create(prescription);
        }

        public String GeneratePrescriptionForPatient(string medicalIdNumber)
        {
            List<EPrescription> prescriptions = GetAllForStub();
            foreach (EPrescription prescription in prescriptions)
            {
                if (prescription.MedicalIDNumber.Equals(medicalIdNumber))
                {
                    return getTextForPrescription(prescription);
                }
            }
            return "";
        }

        public EPrescription createIPrescription(EPrescriptionDto dto)
        {
            return EPrescriptionAdapter.EPrescriptionDtoToEPresctiption(dto);
        }
        private String getTextForPrescription(EPrescription prescription)
        {
            return prescription.Pharmacy + " Precription for medicine\n\nPatients name: " + prescription.Name + "\nPatients surname: " + prescription.Surname + "\nPatients medical ID number: " + prescription.MedicalIDNumber + "\nMedication: " + prescription.Medicine + " Quantity: " + prescription.Quantity + "\nUsage: " + prescription.Usage + "\n";
        }
    }
}
