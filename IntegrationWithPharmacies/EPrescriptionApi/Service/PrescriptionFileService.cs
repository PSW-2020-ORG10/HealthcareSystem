using EPrescriptionApi.AbstractFactory;
using EPrescriptionApi.DbContextModel;
using EPrescriptionApi.Model;
using EPrescriptionApi.Utility;
using System;

namespace EPrescriptionApi.Service
{
    public class PrescriptionFileService
    {
        private SftpService SftpService { get; }
        private HelperFunctions HelperFunctions { get; }
        private HttpRequests HttpRequests { get; }
        private SmptServerService SmptServerService { get; }
        private MyDbContext Context { get; }
        public PharmacyFactoryGrpcAndSftp PharmacyFactoryGrpcAndSftp { get; }
        public PharmacyFactoryHttp PharmacyFactoryHttp { get; }

        public PrescriptionFileService() { }
        public PrescriptionFileService(MyDbContext context) {
            SftpService = new SftpService();
            HelperFunctions = new HelperFunctions();
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
            Context = context;
            PharmacyFactoryGrpcAndSftp = new PharmacyFactoryGrpcAndSftp();
            PharmacyFactoryHttp = new PharmacyFactoryHttp();
        }

        public Boolean SendPrescription(EPrescription prescription)
        {

            try
            {
                foreach (RegistrationInPharmacy registrationInPharmacy in HttpRequests.GetPharmacyRegistrations())
                {
                    if (registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Substring(registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Length - 1).Equals("H"))
                    {
                        IPharmacy ipharmacy = PharmacyFactoryHttp.GetIPharmacy(registrationInPharmacy.PharmacyConnectionInfo.Url, Context);

                        ipharmacy.SendPrescription(prescription);
                    }
                    else
                    {
                        IPharmacy ipharmacy = PharmacyFactoryGrpcAndSftp.GetIPharmacy("", Context);
                        ipharmacy.SendPrescription(prescription);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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
