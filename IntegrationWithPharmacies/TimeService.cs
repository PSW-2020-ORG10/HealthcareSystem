using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using HealthClinic.CL.Model.ActionsAndBenefits;
using IntegrationWithPharmacies;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntegrationWithPharmacies
{
    public class TimeService : BackgroundService
    {
        System.Timers.Timer collectTimer = new System.Timers.Timer();       // periodicly collects new messages from list and writes them to file
        System.Timers.Timer generatorTimer = new System.Timers.Timer();     // periodicly generates new messages and adds them to list

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            collectTimer.Elapsed += new ElapsedEventHandler(CollectMessage);
            collectTimer.Interval = 5000; //number in miliseconds  
            collectTimer.Enabled = true;

          
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
            return base.StopAsync(cancellationToken);
        }

       

        private void CollectMessage(object source, ElapsedEventArgs e)
        {
            WriteToFile("Collect messages at " + DateTime.Now);
            foreach (Message message in Program.ListOfMessages)
            {
                WriteToFile("Message " + message.Text + " sent at " + message.TimeStamp + " was read at the specific time " + DateTime.Now);
            }
            Program.ListOfMessages.Clear();
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
