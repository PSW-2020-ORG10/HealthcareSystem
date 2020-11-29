using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class ReportService
    {
        public ReportRepository ReportRepository { get; }
        private IReportRepository IReportRepository { get; set; }
   

        public ReportService()
        {
            ReportRepository = new ReportRepository();
        }
        
        public void createAndSaveFile()
        {
            DoctorOrderServica orderService = new DoctorOrderServica();
        }

        public object createAndSendFile()
        {
            throw new NotImplementedException();
        }
    }
}
