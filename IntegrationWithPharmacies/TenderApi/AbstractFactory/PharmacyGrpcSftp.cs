using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TenderApi.DbContextModel;
using TenderApi.Model;
using TenderApi.Service;
using TenderApi.Utility;

namespace TenderApi.AbstractFactory
{
    public class PharmacyGrpcSftp : IPharmacyHttp
    {
        private SftpService SftpService { get; }
        private HttpRequests HttpRequests { get; }
        private SmptServerService SmptServerService { get; }
        private ReportText ReportText { get; }

        public PharmacyGrpcSftp() { }
        public PharmacyGrpcSftp(string url, MyDbContext context)
        {
            SftpService = new SftpService();
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
            ReportText = new ReportText(context);
        }

        public bool SendReport(DateOfOrder date)
        {
            try
            {
                String report = ReportText.CreateReport(date);
                String[] reportParts = report.Split('\\');
                SftpService.UploadFile(report, @"\pub\" + reportParts[1]);
                SmptServerService.SendEMailNotification(report, "report");
                return true;
            }
            catch (Exception e) { return false; }
            
        }
    }
}
