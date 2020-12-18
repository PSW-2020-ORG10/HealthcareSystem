using Grpc.Core;
using IntegrationWithPharmacies.Protos;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public class ClientScheduledService
    {
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() { }

        public async Task<string> SendMessage(string name)
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);

            MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = name });
            return response.Response;
        }
    }
} 