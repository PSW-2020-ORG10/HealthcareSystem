using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HealthClinic.CL.Repository
{
    interface IReportRepository
    {
        bool saveFile(String filename);
    }
}
