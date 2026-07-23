using System.Net.Http.Headers;

namespace Concurrency_use_cases.Domain.StripePaiement
{
    public class PaiementService
    {
        private static readonly SemaphoreSlim semaphore = new(5);

        public async Task ProcessPaiement(Order order)
        {
            /* 
             * Quand on passe time param to WaitAsync() il return un Task<bool> si le thread à trouver une place avant que 
             * 2s termine la method return true, so non c'est un timeout donc il return false, et si il return false donc, 
             * on ne doit pas terminer l'execution donc on mait return; pour ne pas venir au block de finally qui execute 
             * Release() qui va incrementer nombres de places, et le thread n'à meme pas execute l'operation
            */
            bool res = await semaphore.WaitAsync(2000);
            if (!res)
                return;

            try
            {
                await StripeService.CallStripeAsync(order);
            } finally
            {
                semaphore.Release();
            }
        }
    }
}
