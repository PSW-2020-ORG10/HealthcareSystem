using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class SftpService : ISpftService
    {
        private readonly ILogger<SftpService> _logger;
        private readonly SftpConfig _config;

        public SftpService(ILogger<SftpService> logger, SftpConfig sftpConfig)
        {
            _logger = logger;
            _config = sftpConfig;
        }

        public bool UploadFile(string localFilePath, string remoteFilePath)
        {
            using var client = new SftpClient("192.168.1.244", 22, "tester", "password");
            try
            {
                client.Connect();
                using var s = File.OpenRead(localFilePath);
                client.UploadFile(s, remoteFilePath);
                _logger.LogInformation($"Finished uploading file [{localFilePath}] to [{remoteFilePath}]");
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in uploading file [{localFilePath}] to [{remoteFilePath}]");
                Console.WriteLine(exception);
                return false;
         
            }
            finally
            {
                client.Disconnect();
            }
        }

        IEnumerable<SftpFile> ISpftService.ListAllFiles(string remoteDirectory)
        {
            using var client = new SftpClient("192.168.56.1", 22, "tester", "password");
            try
            {
                client.Connect();
                return client.ListDirectory(remoteDirectory);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in listing files under [{remoteDirectory}]");
                return null;
            }
            finally
            {
                client.Disconnect();
            }
        }
    }
}
