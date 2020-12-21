using HealthClinic.CL.DbContextModel;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class ReportService
    {   
        private HelperFunctions HelperFunctions { get; }
        private SftpService SftpService { get; }
        private HttpService HttpService { get; }
        private ReportText ReportText { get; }
        private SmptServerService SmptServerService { get; }

        public ReportService(MyDbContext context)
        {
            SftpService = new SftpService();
            HelperFunctions = new HelperFunctions();
            HttpService = new HttpService();
            ReportText = new ReportText(context);
            SmptServerService = new SmptServerService();
        }
        public Boolean SendReportSftp(DateOfOrder date)
        {
            try
            {
                String report = CreateReport(date);
                String []reportParts = report.Split('\\');
                SftpService.UploadFile(report, @"\pub\" + reportParts[1]);
                SmptServerService.SendEMailNotification(report,"report");

                return true;
            }
            catch (Exception e) { return false; }
        }
        public Boolean SendReportHttp(DateOfOrder date)
        {
            String report = CreateReport(date);
            try
            {
                HttpService.UploadReportFile(report);
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
