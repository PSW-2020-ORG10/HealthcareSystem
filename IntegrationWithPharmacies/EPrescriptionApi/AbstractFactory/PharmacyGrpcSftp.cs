using System;
using EPrescriptionApi.DbContextModel;
using EPrescriptionApi.Model;
using EPrescriptionApi.Service;
using EPrescriptionApi.Utility;

namespace EPrescriptionApi.AbstractFactory
{
    public class PharmacyGrpcSftp : IPharmacyHttp
    {

        private SftpService SftpService { get; }
        private HttpRequests HttpRequests { get; }
        private SmptServerService SmptServerService { get; }
        private PrescriptionFileService PrescriptionFileService { get; }

        public PharmacyGrpcSftp() { }

        public PharmacyGrpcSftp( MyDbContext context) {
            SftpService = new SftpService();
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
            PrescriptionFileService = new PrescriptionFileService(context);
        }

        public bool SendPrescription(EPrescription prescription)
        {
            String prescriptionFile = PrescriptionFileService.CreatePrescription(prescription);
            String[] prescriptionParts = prescriptionFile.Split("\\");

            try
            {
                SftpService.UploadFile(prescriptionFile, @"\pub\" + prescriptionParts[1]);
                SmptServerService.SendEMailNotification(prescriptionFile);
                return true;

            }
            catch (Exception e) { return false; }
        }
    }
}
