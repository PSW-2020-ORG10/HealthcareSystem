using System;
using System.IO;
using Renci.SshNet;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class SftpService : ISftpService
    {   
        private SftpClient Client { get; } 
        public SftpService(){
            Client = new SftpClient("192.168.56.1", 22, "tester", "password");
        }

        public Boolean UploadFile(string localFilePath, string remoteFilePath)
        {
            try { return MakeConnection(localFilePath, remoteFilePath);  }

            catch (Exception exceptione) { return false; }
            finally  { Client.Disconnect(); }
        }

        private bool MakeConnection(string localFilePath, string remoteFilePath)
        {
            Client.Connect();
            Client.UploadFile(File.OpenRead(localFilePath), remoteFilePath);
            return true;
        }

    }
}
