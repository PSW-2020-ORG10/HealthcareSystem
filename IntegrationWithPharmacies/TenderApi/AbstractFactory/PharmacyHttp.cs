using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TenderApi.DbContextModel;
using TenderApi.Model;
using TenderApi.Service;
using TenderApi.Utility;

namespace TenderApi.AbstractFactory
{
    public class PharmacyHttp : IPharmacyHttp
    {
        
        private SftpService SftpService { get; }
        private HttpRequests HttpRequests { get; }
        private SmptServerService SmptServerService { get; }
        private ReportText ReportText { get; }

        public PharmacyHttp() { }
        public PharmacyHttp(MyDbContext context)
        {
            SftpService = new SftpService();
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
            ReportText = new ReportText(context);
        }

        public bool SendReport(DateOfOrder date)
        {
            String report = ReportText.CreateReport(date);
            try
            {
                HttpRequests.UploadReportFile(report);
                SmptServerService.SendEMailNotification(report, "report");
                return true;
            }
            catch (Exception e) { return false; }
        }
    }
}
