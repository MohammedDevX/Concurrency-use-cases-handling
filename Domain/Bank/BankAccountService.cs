namespace Concurrency_use_cases.Domain.Bank
{
    public class BankAccountService
    {
        public bool Withdraw(BankAccount bankAccount, double amount)
        {
            while (true)
            {
                double result;
                double current = bankAccount._balance;
                if (current < amount || current == 0 || amount <= 0)
                {
                    throw new ArgumentException("Please select amount that are less than balance account and positive");
                }
                else
                {
                    result = current - amount;
                }

                if (Interlocked.CompareExchange(ref bankAccount.BalanceRef, result, current) != current)
                {
                    
                } else
                {
                    return true;
                }
            }
        }
    }
}
