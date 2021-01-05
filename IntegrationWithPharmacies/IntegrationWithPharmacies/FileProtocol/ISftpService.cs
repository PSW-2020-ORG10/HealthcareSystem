using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;

namespace IntegrationWithPharmacies.FileProtocol
{
    public interface ISftpService
    {
        Boolean UploadFile(string localFilePath, string remoteFilePath);
    }
}
