using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using IntegrationWithPharmacies.HelperClasses;

namespace IntegrationWithPharmacies
{
    public class Program
    {
        public static object Messages { get; internal set; }
        public static List<Message> ListOfMessages = new List<Message>();
        public static void Main(string[] args)
        {
            //CreateHostBuilderMessages(args).Build().Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   var port = Environment.GetEnvironmentVariable("PORT");

                   webBuilder.UseStartup<Startup>()
                   .UseUrls("http://*:" + port);

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