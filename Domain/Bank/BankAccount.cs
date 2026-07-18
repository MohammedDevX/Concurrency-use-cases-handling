namespace Concurrency_use_cases.Domain.Bank
{
    public class BankAccount(double balance)
    {
        private double Balance = balance >= 0 ? balance : throw new ArgumentException("The balance should be higher or equal 0");
        public ref double BalanceRef => ref Balance; // Get the reference of private field Balance to use it outside this class

        public double _balance
        {
            get => Balance;
            set => Balance = value;
        }
    }
}
