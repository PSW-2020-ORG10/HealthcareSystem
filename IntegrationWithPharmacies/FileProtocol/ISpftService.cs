using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.FileProtocol
{
    public interface ISpftService
    {
        IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".");
        Boolean UploadFile(string localFilePath, string remoteFilePath);
    }
}
