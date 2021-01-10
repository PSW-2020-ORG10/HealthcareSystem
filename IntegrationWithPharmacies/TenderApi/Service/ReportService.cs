using System;
using TenderApi.DbContextModel;
using TenderApi.Model;
using TenderApi.Utility;

namespace TenderApi.Service
{
    public class ReportService
    {
        private HelperFunctions HelperFunctions { get; }
        private SftpService SftpService { get; }
        private HttpRequests HttpRequests { get; }
        private ReportText ReportText { get; }
        private SmptServerService SmptServerService { get; }

        public ReportService(MyDbContext context)
        {
            SftpService = new SftpService();
            HelperFunctions = new HelperFunctions();
            HttpRequests = new HttpRequests();
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
                SmptServerService.SendEMailNotification(report, "report");

                return true;
            }
            catch (Exception e) { return false; }
        }
        public Boolean SendReportHttp(DateOfOrder date)
        {
            String report = CreateReport(date);
            try
            {
                HttpRequests.UploadReportFile(report);
                SmptServerService.SendEMailNotification(report, "report");
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
    }
}
