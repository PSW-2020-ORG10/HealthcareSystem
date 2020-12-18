using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HealthClinic.CL.Model.ActionsAndBenefits;
using HealthClinic.CL.Service;
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
                try{  message = JsonConvert.DeserializeObject<Message>(jsonMessage); }
                catch (Exception)   
                {
                    message = JsonConvert.DeserializeObject<Message>(jsonMessage, new MyDateTimeConverter());
                }
                Program.ListOfMessages.Add(message);
             
                MessageService messageService = new MessageService();
                //messageService.Create(new MessageDto(message.Text, message.TimeStamp, "Apoteka Jankovic", message.DateAction));

            };
            channel.BasicConsume(queue: "hello",autoAck: true, consumer: consumer);
            return base.StartAsync(cancellationToken);
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
