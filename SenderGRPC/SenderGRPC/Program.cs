using Grpc.Net.Client;
using SenderGRPC.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using TransactionAgent;

namespace SenderGRPC
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Publisher has started on!");
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                
            var channel = GrpcChannel.ForAddress(Settings.IPAdress);
            var client = new ExecuteTransaction.ExecuteTransactionClient(channel);
            var request = new TransactionMessage();
            while (true)
            {
                Console.Write("Enter owner id: ");
                request.OwnerCardId = Console.ReadLine().ToLower();

                Console.Write("Enter recipient id: ");
                request.RecipientCardId = Console.ReadLine().ToLower();

                Console.Write("Enter transaction type: ");
                var transactiontype = Console.ReadLine();
                request.TransactionType = (TypeTransaction)Enum.Parse(typeof(TypeTransaction), transactiontype);

                Console.Write("Enter currency: ");
                request.Ccy = Console.ReadLine().ToLower();

                Console.Write("Enter the summ: ");
                request.TransactionSumm = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter additional comments: ");
                request.AditionalComment = Console.ReadLine().ToLower();
                try
                {
                    var reply = await client.PublicTransactionAsync(request);
                    Console.Write($"Publish reply: {reply.Status}");
                }
                catch(Exception e)
                {
                    Console.Write($"Error publishing message: {e.Message}");
                }
            }
        }
    }
}
