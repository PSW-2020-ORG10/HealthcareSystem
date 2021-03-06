﻿using Grpc.Core;
using System.Threading.Tasks;
using UrgentMedicineOrderApi.Protos;
namespace UrgentMedicineOrderApi.Service
{
    public class ClientScheduledService
    {
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() { }

        public async Task<string> SendMessage(string name)
        {
            client = new SpringGrpcService.SpringGrpcServiceClient(new Channel("127.0.0.1:8787", ChannelCredentials.Insecure));

            MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = name });
            return response.Response;
        }
    }
}