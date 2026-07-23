namespace Concurrency_use_cases.Domain.StripePaiement
{
    public class Order
    {
        public int Id { get; }
        public decimal Amount { get; }

        public Order(int id, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            Id = id;
            Amount = amount;
        }
    }
}
