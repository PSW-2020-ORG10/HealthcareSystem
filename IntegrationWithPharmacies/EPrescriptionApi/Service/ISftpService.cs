using System;

namespace EPrescriptionApi.Service
{
    public interface ISftpService
    {
        Boolean UploadFile(string localFilePath, string remoteFilePath);
    }
}
