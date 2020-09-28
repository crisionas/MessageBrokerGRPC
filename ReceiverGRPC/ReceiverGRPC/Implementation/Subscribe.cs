using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerAgent;

namespace ReceiverGRPC.Implementation
{
    public class Subscribe
    {
        public static void SubscribeData(IWebHost host)
        {
            var channel = GrpcChannel.ForAddress(Settings.IPAdress);
            var client = new WorkerRegistration.WorkerRegistrationClient(channel);


            var address = host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First();

            Console.WriteLine($"Receiver listen at {address}");
            Random random = new Random();
            string randomNumber = random.Next(1, 1000).ToString();
            var request = new WorkerMessage() { WorkerId = randomNumber, WorkerAdress = address };

            try
            {
                var reply = client.RegisterWorker(request);
                Console.WriteLine($"Worker reply: {reply.Status},");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
            }
        }
    }
}
