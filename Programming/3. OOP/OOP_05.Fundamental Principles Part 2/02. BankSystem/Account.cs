using System;

namespace BankSystem
{
    public abstract class Account : IDepositable
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        protected DateTime OpenDate { get; set; }
        public decimal Interest { get; set; }
        public int TotalMonthDuration
        {
            get
            {
                return (int)((DateTime.Today - this.OpenDate).TotalDays / 30);
            }
        }

        protected Account(Customer accCust, decimal interest, DateTime date, decimal saldo)
        {
            this.Customer = accCust;
            this.Interest = interest;
            this.Balance = saldo;
            this.OpenDate = date;
        }

        protected Account(Customer accCust, decimal interest) : this(accCust, interest, DateTime.Now, 0m)
        {
        }

        public abstract decimal CalcInterest(int months);

        public virtual void Deposit(decimal amount)     
        {
            if (amount >= 0)
            {
                this.Balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The deposited amount could not be negative!");
            }
        }

        public override string ToString()
        {
            return string.Format("{0} for {1} {2:0.00} BGN, {3:p}, months: {4}", this.GetType().Name, this.Customer, this.Balance, this.Interest, this.TotalMonthDuration);
        }
    }
}
