using MedicineReportApi.DbContextModel;
using MedicineReportApi.Model;
using MedicineReportApi.Utility;
using System;
using System.Net;

namespace MedicineReportApi.Service
{
    public class ReportService
    {
        private HelperFunctions HelperFunctions { get; }
        private SftpService SftpService { get; }
        private ReportText ReportText { get; }
        private SmptServerService SmptServerService { get; }

        public ReportService(MyDbContext context)
        {
            SftpService = new SftpService();
            HelperFunctions = new HelperFunctions();
            ReportText = new ReportText(context);
            SmptServerService = new SmptServerService();
        }
        public Boolean SendReportSftp(DateOfOrder date)
        {
            try
            {
                String report = CreateReport(date);
                String[] reportParts = report.Split('\\');
                SftpService.UploadFile(report, @"\pub\" + reportParts[1]);
                SmptServerService.SendEMailNotification(report);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public Boolean SendReportHttp(DateOfOrder date)
        {
            String report = CreateReport(date);
            try
            {
                UploadReportFile(report);
                SmptServerService.SendEMailNotification(report);
                return true;
            }
            catch (Exception e) { return false; }
        }

        public String CreateReport(DateOfOrder date)
        {
            String complete = @"FileReports\Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + HelperFunctions.GetRandomNumber() + ".txt";
            System.IO.File.WriteAllText(complete, ReportText.GetRegistredPharmacies() + "!    Report about consumption of medicine\n\n\n" + ReportText.getReportText(date));
            return complete;
        }
        public void UploadReportFile(String complete)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadFile(new Uri(@"http://localhost:8082/download/file/http"), "POST", complete);
            client.Dispose();
        }
    }
}
