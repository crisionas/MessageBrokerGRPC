using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerAgent;

namespace ReceiverGRPC.Services
{
    public class Worker :WorkerRegistration.WorkerRegistrationBase
    {
        public Task<ConfirmationResponse> Response(WorkerMessage data,ServerCallContext context)
        {
            return Task.FromResult(new ConfirmationResponse()
            {
                Status = true

            }) ;
        }
    }
}
