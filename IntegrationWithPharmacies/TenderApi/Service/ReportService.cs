using System;
using System.Collections.Generic;
using TenderApi.AbstractFactory;
using TenderApi.DbContextModel;
using TenderApi.Model;
using TenderApi.Utility;

namespace TenderApi.Service
{
    public class ReportService
    {
        public PharmacyFactoryGrpcAndSftp PharmacyFactoryGrpcAndSftp { get; }
        public PharmacyFactoryHttp PharmacyFactoryHttp { get; }
        private MyDbContext Context { get; }

        public ReportService(MyDbContext context)
        {
            PharmacyFactoryGrpcAndSftp = new PharmacyFactoryGrpcAndSftp();
            PharmacyFactoryHttp = new PharmacyFactoryHttp();
            Context = context;
        }

        public Boolean SendReport(DateOfOrder date)
        {
            try
            {
                foreach (RegistrationInPharmacy registrationInPharmacy in HttpRequests.GetRegistrationsInPharmaciesAll())
                {
                    if (registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Substring(registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Length - 1).Equals("H"))
                    {
                        IPharmacy ipharmacy = PharmacyFactoryHttp.GetIPharmacy(registrationInPharmacy.PharmacyConnectionInfo.Url, Context);

                        ipharmacy.SendReport(date);
                    }
                    else
                    {
                        IPharmacy ipharmacy = PharmacyFactoryGrpcAndSftp.GetIPharmacy("", Context);
                        ipharmacy.SendReport(date);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

      
    }
}
