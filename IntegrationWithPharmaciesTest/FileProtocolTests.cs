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

            var testFile = @"C:\Users\Mladenka\Desktop\psw\HealthcareSystem\IntegrationWithPharmacies\test.txt";

            mock.Setup(verify =>  verify.UploadFile(testFile, @"\pub\test.txt"));
        }
        [Fact]
        public static void Sends_no_file_using_file_protocol()
        {
            var mock = new Mock<ISpftService>();

            var testFile = @"C:\Users\Mladenka\Desktop\psw\HealthcareSystem\IntegrationWithPharmacies\wrong.txt";
            mock.Setup(verify => verify.UploadFile(testFile, @"\pub" + Path.GetFileName(testFile)));

        }

    }
   
}
