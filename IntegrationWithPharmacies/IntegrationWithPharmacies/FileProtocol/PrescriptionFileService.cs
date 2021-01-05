using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class PrescriptionFileService
    {
        private SftpService SftpService { get; }
        private HelperFunctions HelperFunctions { get; }
        private HttpService HttpService { get; }
        private SmptServerService SmptServerService { get; }

        public PrescriptionFileService(MyDbContext context) {
            SftpService = new SftpService();
            HelperFunctions = new HelperFunctions();
            HttpService = new HttpService();
            SmptServerService = new SmptServerService();
        }

        public Boolean SendPrescriptionSftp(EPrescription prescription)
        {
            String prescriptionFile = CreatePrescription(prescription);
            String[] prescriptionParts = prescriptionFile.Split("\\");

            try {
                SftpService.UploadFile(prescriptionFile, @"\pub\" + prescriptionParts[1]);
                SmptServerService.SendEMailNotification(prescriptionFile, "prescription");
                return true;

            }
            catch (Exception e) { return false; }
        }

        public Boolean SendPrescriptionHttp(EPrescription prescription)
        {
            String prescriptionFile = CreatePrescription(prescription);
            try
            {
                HttpService.UploadPrescriptionFile(prescriptionFile);
                SmptServerService.SendEMailNotification(prescriptionFile, "prescription");
                return true;}
            catch (Exception e) { return false; }
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
