using System;

namespace BankSystem
{
    public class Deposit : Account, IWithdrawable
    {
        public Deposit(Customer cust, decimal interest, DateTime date, decimal saldo)
            : base(cust, interest, date, saldo)
        {
        }

        public Deposit(Customer cust, decimal interest)
            : base(cust, interest)
        {
        }

        public override decimal CalcInterest(int months)
        {
            if (months >= 0)
            {
                if (base.Balance < 1000 && base.Balance >= 0)
                {
                    return 0;
                }
                else
                {
                    return base.Interest * months * base.Balance;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The period in months could not be negative!");
            }
        }

        public void Withdraw(decimal amount)        //the deposits could have negative balance, only the amount must be positive
        {
            if (amount > 0)
            {
                this.Balance -= amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The withdrawn amount could not be negative!");
            }
        }
    }
}
