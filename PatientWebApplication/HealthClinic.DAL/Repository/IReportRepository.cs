using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HealthClinic.CL.Repository
{
    interface IReportRepository
    {
        Boolean saveFile(String filename);
    }
}
