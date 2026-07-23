using System.Threading.Channels;

namespace Concurrency_use_cases.Domain.OrdernigProducts
{
    public class EmailBackgroundService(Channel<EmailJob> channel)
    {
        public async Task RunAsync()
        {
            await foreach (var job in channel.Reader.ReadAllAsync())
            {
                await SendEmail(job);

                Console.WriteLine($"The email service worker has processed the orderId : {job.OrderId}");
            }
        }

        private async Task SendEmail(EmailJob emailJob) 
        {
            Console.WriteLine($"Hello Mr you have already created an order with Id : {emailJob.OrderId} " +
                $"and the amount is {emailJob.Amount}");

            await Task.Delay(1000);

            Console.WriteLine("The email is sended to : " + emailJob.Email);
        }
    }
}
