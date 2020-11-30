using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using HealthClinic.CL.Model.ActionsAndBenefits;
using Microsoft.Extensions.Hosting;

namespace IntegrationWithPharmacies
{
    public class TimeService : BackgroundService
    {
        System.Timers.Timer collectTimer = new System.Timers.Timer();        // periodicly generates new messages and adds them to list

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
                WriteToFile("Message " + message.Text + " sent at " + message.TimeStamp + " was read at " + DateTime.Now);
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