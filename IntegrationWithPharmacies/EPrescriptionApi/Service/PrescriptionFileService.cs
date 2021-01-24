using EPrescriptionApi.AbstractFactory;
using EPrescriptionApi.DbContextModel;
using EPrescriptionApi.Model;
using EPrescriptionApi.Utility;
using System;
using System.Net.Http.Headers;

namespace EPrescriptionApi.Service
{
    public class PrescriptionFileService
    {
        private HelperFunctions HelperFunctions { get; }
        private MyDbContext Context { get; }
        public PharmacyFactoryGrpcAndSftp PharmacyFactoryGrpcAndSftp { get; }
        public PharmacyFactoryHttp PharmacyFactoryHttp { get; }

        public PrescriptionFileService() { }
        public PrescriptionFileService(MyDbContext context) {
            HelperFunctions = new HelperFunctions();
            Context = context;
            PharmacyFactoryGrpcAndSftp = new PharmacyFactoryGrpcAndSftp();
            PharmacyFactoryHttp = new PharmacyFactoryHttp();
        }

        public Boolean SendPrescription(EPrescription prescription)
        {
            try
            {
                foreach (RegistrationInPharmacy registrationInPharmacy in HttpRequests.GetPharmacyRegistrations()) DefineTypeOfApiKey(prescription, registrationInPharmacy);
                return true;
            }
            catch (Exception e) { return false; }
        }

        private void DefineTypeOfApiKey(EPrescription prescription, RegistrationInPharmacy registrationInPharmacy)
        {
            if (registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Substring(registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Length - 1).Equals("H"))
            {
                new PharmacyHttp(Context).SendPrescription(prescription);
            }
            else new PharmacyGrpcSftp(Context).SendPrescription(prescription);
        }

        public String CreatePrescription(EPrescription prescription)
        {
            String complete = @"FilePrescriptions\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + HelperFunctions.GetRandomNumber() + ".txt";
            System.IO.File.WriteAllText(complete, GetTextForPrescription(prescription));
            return complete;
        }

        public String GetTextForPrescription(EPrescription prescription)
        {
            return prescription.Pharmacy + " Precription for medicine\n\nPatients name: " + prescription.Name + "\nPatients surname: " + prescription.Surname + "\nPatients medical ID number: " + prescription.MedicalIDNumber + "\nMedication: " + prescription.Medicine + " Quantity: " + prescription.Quantity + "\nUsage: " + prescription.Usage + "\n";
        }
    }
}
