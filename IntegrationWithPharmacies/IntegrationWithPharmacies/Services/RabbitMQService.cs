using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IntegrationWithPharmacies.HelperClasses;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace IntegrationWithPharmacies
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                Message message;
                try { message = JsonConvert.DeserializeObject<Message>(jsonMessage); }
                catch (Exception)
                {
                    message = JsonConvert.DeserializeObject<Message>(jsonMessage, new MyDateTimeConverter());
                }
                Program.ListOfMessages.Add(message);
                Console.WriteLine(message.TimeStamp);
                string dates = message.TimeStamp.ToString();
                string[] listOfDates = dates.Split(' ');

                _ = CreateNewMedicineWithQuantityAsync(new MessageDto(message.Text, listOfDates[0], message.TimeStamp, "Apoteka Jankovic", message.DateAction));

            };
            channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
            return base.StartAsync(cancellationToken);
        }
        public async Task CreateNewMedicineWithQuantityAsync(MessageDto messageDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(CreateActionAndBenefit(messageDto), Formatting.Indented), Encoding.UTF8, "application/json");
            await new HttpClient().PostAsync($"http://localhost:54679/api/message", content);
        }

        private static Dictionary<string, object> CreateActionAndBenefit(MessageDto messageDto)
        {            
            return new Dictionary<string, object>
            {
                {"text", messageDto.Text }, {"DateStamp", messageDto.DateStamp},{"timeStamp",  messageDto.TimeStamp },{"pharmacyName", messageDto.PharmacyName},{"dateAction", messageDto.DateAction}
            };
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
