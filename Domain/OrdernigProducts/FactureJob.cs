namespace Concurrency_use_cases.Domain.OrdernigProducts
{
    public record FactureJob
    {
        public int ClientId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public required string ClientFullName { get; set; }
    }
}
