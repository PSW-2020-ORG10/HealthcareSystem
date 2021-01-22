using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EPrescriptionApi.DbContextModel;
using EPrescriptionApi.Model;
using EPrescriptionApi.Service;
using EPrescriptionApi.Utility;

namespace EPrescriptionApi.AbstractFactory
{
    public class PharmacyGrpcSftp : IPharmacyHttp
    {
 
        public PharmacyGrpcSftp() { }
        public PharmacyGrpcSftp(string url, MyDbContext context)
        {
          
        }

        public bool SendPrescription(EPrescription prescription)
        {
            throw new NotImplementedException();
        }
    }
}
