namespace Concurrency_use_cases.Domain.Bank
{
    public class BankAccountService
    {
        public bool Withdraw(BankAccount bankAccount, double amount)
        {
            while (true)
            {
                double result;
                // Here we made the value of balance account in variable to store it in CPU register for fast read also 
                // if the value of balance change doesnt trigered data incoherence
                double current = bankAccount.Balance;
                if (current < amount || current == 0 || amount <= 0)
                {
                    throw new ArgumentException("Please select amount that are less than balance account and positive");
                }
                else
                {
                    result = current - amount;
                }

                if (Interlocked.CompareExchange(ref bankAccount.BalanceRef, result, current) == current)
                {
                    return true;   
                }
            }
        }
    }
}
