using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;

namespace TenderApi.Service
{
    public interface ISftpService
    {
        Boolean UploadFile(string localFilePath, string remoteFilePath);
    }
}
