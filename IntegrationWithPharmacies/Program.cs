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
using Microsoft.Extensions.Logging;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Adapters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HealthClinic.CL.Model.ActionsAndBenefits;

namespace IntegrationWithPharmacies
{
    public class Program
    {
        public static object Messages { get; internal set; }
        public static List<Message> ListOfMessages = new List<Message>();

        public static void Main(string[] args)
        {
            CreateHostBuilderMessages(args).Build();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHostBuilder CreateHostBuilderMessages(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<TimeService>();
                    services.AddHostedService<RabbitMQService>();
                 });
    }
}
