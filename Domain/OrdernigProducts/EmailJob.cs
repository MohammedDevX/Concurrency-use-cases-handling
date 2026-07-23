using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Concurrency_use_cases.Domain.OrdernigProducts
{
    public record EmailJob
    {
        public required string Email { get; init; }
        public int OrderId { get; init; }
        public decimal Amount { get; init; }
    }
}
