using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ReceiverGRPC.Implementation;

namespace ReceiverGRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(Settings.IPAdressSubscriber)
                .Build();
                host.Start();
            Subscribe.SubscribeData(host);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
