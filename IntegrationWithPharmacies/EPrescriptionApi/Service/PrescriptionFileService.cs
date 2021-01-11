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

        public PrescriptionFileService() {
            SftpService = new SftpService();
            HelperFunctions = new HelperFunctions();
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
        }

        public Boolean SendPrescriptionSftp(EPrescription prescription)
        {
            String prescriptionFile = CreatePrescription(prescription);
            String[] prescriptionParts = prescriptionFile.Split("\\");

            try {
                SftpService.UploadFile(prescriptionFile, @"\pub\" + prescriptionParts[1]);
                SmptServerService.SendEMailNotification(prescriptionFile);
                return true;

            }
            catch (Exception e) { return false; }
        }

        public Boolean SendPrescriptionHttp(EPrescription prescription)
        {
            String prescriptionFile = CreatePrescription(prescription);
            try
            {
                HttpRequests.UploadPrescriptionFile(prescriptionFile);
                SmptServerService.SendEMailNotification(prescriptionFile);
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
