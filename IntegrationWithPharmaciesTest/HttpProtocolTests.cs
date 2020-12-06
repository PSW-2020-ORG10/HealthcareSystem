using IntegrationWithPharmacies.FileProtocol;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
namespace IntegrationWithPharmaciesTest
{
    public class HttpProtocolTests
    {
        [Fact]
        public static void Sends_file_using_http_protocol()
        {
            var mock = new Mock<ISpftService>();

            var testFile = @"..\test.txt";
            mock.Setup(verify => verify.UploadFileHttp(testFile, @"\pub" + Path.GetFileName(testFile))).Returns(true);


        }
        [Fact]
        public static void Sends_no_file_using_http_protocol()
        {
            var mock = new Mock<ISpftService>();

            var testFile = @"..\wrong.txt";
            mock.Setup(verify => verify.UploadFileHttp(testFile, @"\pub" + Path.GetFileName(testFile))).Returns(true);
        }
    }
}
