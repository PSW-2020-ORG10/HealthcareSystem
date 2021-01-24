using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EPrescriptionApi.DbContextModel;
using EPrescriptionApi.Model;
using EPrescriptionApi.Service;
using EPrescriptionApi.Utility;

namespace EPrescriptionApi.AbstractFactory
{
    public class PharmacyHttp : IPharmacyHttp
    {
        private SftpService SftpService { get; }
        private HttpRequests HttpRequests { get; }
        private SmptServerService SmptServerService { get; }

        private PrescriptionFileService PrescriptionFileService { get; }
        public PharmacyHttp() { }
        public PharmacyHttp(MyDbContext context)
        {
            Console.WriteLine("***************************************          TUUUUUUUUUU");
            SftpService = new SftpService();
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
            PrescriptionFileService = new PrescriptionFileService(context);
        }

        public bool SendPrescription(EPrescription prescription)
        {
            String prescriptionFile = PrescriptionFileService.CreatePrescription(prescription);
            try
            {
                HttpRequests.UploadPrescriptionFile(prescriptionFile);
                SmptServerService.SendEMailNotification(prescriptionFile);
                return true;
            }
            catch (Exception e) { return false; }
        }
    }
}
