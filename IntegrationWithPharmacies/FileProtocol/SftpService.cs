using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class SftpService : ISftpService
    {
        private readonly ILogger<SftpService> Logger;
        private readonly SftpConfig Config;

        public SftpService(ILogger<SftpService> logger, SftpConfig sftpConfig)
        {
            Logger = logger;
            Config = sftpConfig;
        }

        public Boolean UploadFile(string localFilePath, string remoteFilePath)
        {
            using var client = new SftpClient("192.168.1.244", 22, "tester", "password");
            try
            {   client.Connect();
                client.UploadFile(File.OpenRead(localFilePath), remoteFilePath);
                return true;
            }

            catch (Exception exceptione) { return false; }

            finally  { client.Disconnect(); }
        }

        IEnumerable<SftpFile> ISftpService.ListAllFiles(string remoteDirectory)
        {
            using var client = new SftpClient("192.168.1.244", 22, "tester", "password");
            try
            {   client.Connect();
                return client.ListDirectory(remoteDirectory);
            }
            catch (Exception exception) { return null; }
            finally { client.Disconnect(); }
        }
    }
}
