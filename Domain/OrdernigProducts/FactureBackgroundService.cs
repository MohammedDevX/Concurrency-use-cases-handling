using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

namespace Concurrency_use_cases.Domain.OrdernigProducts
{
    public class FactureBackgroundService(Channel<FactureJob> channel)
    {
        public async Task RunAsync()
        {
            await foreach (var job in channel.Reader.ReadAllAsync())
            {
                await GenerateFacture(job);

                Console.WriteLine($"The facture service worker has processed the orderId : {job.OrderId}");
            }
        }

        private async Task GenerateFacture(FactureJob job) 
        {
            await Task.Delay(2000);

            Console.WriteLine("Header of facture");

            Console.WriteLine($"The order Id : {job.OrderId} has been creted by {job.ClientFullName}, the amount of " +
                $"order is : {job.Amount}");

            Console.WriteLine("End of facture");
        }
    }
}
