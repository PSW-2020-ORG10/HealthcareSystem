using Microsoft.AspNetCore.Mvc;
using System;
using TenderApi.DbContextModel;
using TenderApi.Model;

namespace TenderApi.AbstractFactory
{
    public interface IPharmacy
    {
        Boolean SendReport(DateOfOrder date);
    }
}
