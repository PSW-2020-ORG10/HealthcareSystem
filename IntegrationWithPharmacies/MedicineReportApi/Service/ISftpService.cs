using System;

namespace MedicineReportApi.Service
{
    public interface ISftpService
    {
        Boolean UploadFile(string localFilePath, string remoteFilePath);
    }
}
