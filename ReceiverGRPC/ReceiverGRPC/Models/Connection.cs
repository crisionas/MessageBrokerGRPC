using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiverGRPC.Models
{
    public class Connection
    {
        public Connection(string address, string worker)
        {
            IpAdress = address;
            worker_id = worker;
        }
        public string IpAdress{ get; set; }
        public string worker_id { get; set; }
    }
}
