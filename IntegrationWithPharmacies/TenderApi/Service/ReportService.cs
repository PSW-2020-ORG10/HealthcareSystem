using System;
using TenderApi.AbstractFactory;
using TenderApi.DbContextModel;
using TenderApi.Model;

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
                foreach (RegistrationInPharmacy registrationInPharmacy in HttpRequests.GetRegistrationsInPharmaciesAll()) DefineTyepOfApiKey(date, registrationInPharmacy);
                return true;
            }
            catch(Exception e){ return false; }
        }

        private void DefineTyepOfApiKey(DateOfOrder date, RegistrationInPharmacy registrationInPharmacy)
        {
            if (registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Substring(registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Length - 1).Equals("H"))
            {
                PharmacyFactoryHttp.GetIPharmacy(Context).SendReport(date);
            }
            else PharmacyFactoryGrpcAndSftp.GetIPharmacy(Context).SendReport(date);
        }
    }
}
