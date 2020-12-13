using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;

namespace IntegrationWithPharmacies.FileProtocol
{
    public interface ISftpService
    {
        IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".");
        Boolean UploadFile(string localFilePath, string remoteFilePath);
    }
}
