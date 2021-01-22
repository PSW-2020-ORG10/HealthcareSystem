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
        public PharmacyHttp() { }
        public PharmacyHttp(String url, MyDbContext context)
        {
           
        }

        public bool SendPrescription(EPrescription prescription)
        {
            throw new NotImplementedException();
        }
    }
}
