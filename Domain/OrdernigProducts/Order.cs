namespace Concurrency_use_cases.Domain.OrdernigProducts
{
    public class Order
    {
        public int Id { get; init; }
        public int ClientId { get; init; }
        public decimal Amount { get; set; }
    }
}
