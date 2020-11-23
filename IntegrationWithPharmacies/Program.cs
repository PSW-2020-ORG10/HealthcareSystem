using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Adapters;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.Extensions.Logging.Abstractions;
using System.IO;

namespace IntegrationWithPharmacies
{
    public class Program
    {
    public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var config = new SftpConfig
            {
                Host = "192.168.0.28",
                Port = 22,
                UserName = "tester",
                Password = "password"
            };
            var sftpService = new SftpService(new NullLogger<SftpService>(), config);
            /*
            // list files
            var files = sftpService.ListAllFiles("/pub/example");
            foreach (var file in files)
            {
                if (file.IsDirectory)
                {
                    Console.WriteLine($"Directory: [{file.FullName}]");
                }
                else if (file.IsRegularFile)
                {
                    Console.WriteLine($"File: [{file.FullName}]");
                }
            }
            */
            // upload a file // not working for this demo SFTP server due to readonly permission
           // Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            var testFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt");
           // var testFile = @"D:\FAKULTET\4. GODINA\Projektovanje softvera\ProjekatPsw\test.txt";
            sftpService.UploadFile(testFile, @"\public\test.txt");
          
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
