using System.Threading.Channels;

namespace Concurrency_use_cases.Domain.OrdernigProducts
{
    public class OrderService(Channel<EmailJob> EmailChannel, Channel<FactureJob> FactureChannel)
    {
        public async Task CreateOrder(Order request, string email, string fullName)
        {
            // Save order in DB 
            await Task.Delay(1000);

            Console.WriteLine($"Commande with id : {request.Id} is created");

            await EmailChannel.Writer.WriteAsync(new EmailJob
            {
                Email = email,
                OrderId = request.Id,
                Amount = request.Amount
            });

            await FactureChannel.Writer.WriteAsync(new FactureJob
            {
                ClientId = request.ClientId,
                Amount = request.Amount,
                OrderId = request.Id,
                ClientFullName = fullName
            });

            Console.WriteLine($"Email {email} is added in the Email channel && order : {request.Id} is add to Facture channel");
        }
    }
}
