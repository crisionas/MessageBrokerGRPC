using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionAgent;

namespace ReceiverGRPC.Services
{
    public class Transaction:ExecuteTransaction.ExecuteTransactionBase
    {
        public Task<TransactionResponse> ResponseMessage(TransactionMessage request, ServerCallContext context)
        {
            Console.WriteLine($"Received: {request.OwnerCardId} {request.RecipientCardId} {request.Ccy} {request.TransactionType} " +
                $"{request.TransactionSumm} {request.AditionalComment}");
            return Task.FromResult(new TransactionResponse()
            {
                Status = true,
                Message = "Transaction successful arrived."
            });
        }
    }
}
