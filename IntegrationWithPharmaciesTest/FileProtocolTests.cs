using IntegrationWithPharmacies.FileProtocol;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class FileProtocolTests
    {
        [Fact]
        public static void Sends_file_using_file_protocol()
        {
            var mock = new Mock<ISpftService>();

            var testFile = @"D:\FAKULTET\4. GODINA\Projektovanje softvera\ProjekatPsw\test.txt";

            mock.Verify(verify =>  verify.UploadFile(testFile, @"\public\test.txt"),Times.Once);
        }
  
    }
}
