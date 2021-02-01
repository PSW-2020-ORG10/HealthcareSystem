using Microsoft.AspNetCore.Mvc;
using System;
using EPrescriptionApi.DbContextModel;
using EPrescriptionApi.Model;

namespace EPrescriptionApi.AbstractFactory
{
    public interface IPharmacy
    {
        Boolean SendPrescription(EPrescription prescription);
    }
}
