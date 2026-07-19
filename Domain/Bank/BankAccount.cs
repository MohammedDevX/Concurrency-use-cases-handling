namespace Concurrency_use_cases.Domain.Bank
{
    public class BankAccount(double balance)
    {
        private double _balance = balance >= 0 ? balance : throw new ArgumentException("The balance should be higher or equal 0");

        public double Balance
        {
            get => _balance;
        }

        /* 
         * internal to dont expose the reference outside this project, temp solution, to fix it, should to made the logique 
         * in the entity
        */
        internal ref double BalanceRef => ref _balance; // Get the reference of private field Balance to use it outside this class
    }
}
