using Concurrency_use_cases.Domain.Bank;
using Concurrency_use_cases.Domain.OrdernigProducts;
using System.Collections;
using System.Text;
using System.Threading.Channels;
//using System.Runtime.CompilerServices;

//BankAccount account = new(1321);

//void ChangeBalance(ref double balance)
//{
//    balance = 120;
//}

//ChangeBalance(ref account.BalanceRef);
//Console.WriteLine(account.Balance);



Channel<EmailJob> emailchannel = Channel.CreateBounded<EmailJob>(100);
Channel<FactureJob> facturechannel = Channel.CreateBounded<FactureJob>(100);

OrderService orderService = new(emailchannel, facturechannel);

EmailBackgroundService emailBackgroundService = new(emailchannel);
FactureBackgroundService factureBackgroundService = new(facturechannel);

_ = Task.Run(() => emailBackgroundService.RunAsync());
_ = Task.Run(() => factureBackgroundService.RunAsync());

Order order = new()
{
    Id = 1249,
    ClientId = 102,
    Amount = 142
};

await orderService.CreateOrder(order, "mohammed@gmail.com", "Bakhtaoui Mohammed");
await Task.Delay(5000);

