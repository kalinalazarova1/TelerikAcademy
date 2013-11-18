using System;

namespace BankSystem
{
    public class Loan : Account
    {
        public Loan(Customer cust, decimal interest, DateTime date, decimal saldo)
            : base(cust, interest, date, saldo)
        {
        }

        public Loan(Customer cust, decimal interest)
            : base(cust, interest)
        {
        }

        public override decimal CalcInterest(int months)
        {
            if (months >= 0)
            {
                if (this.Customer is Person && base.TotalMonthDuration <= 3 || this.Customer is Company && base.TotalMonthDuration <= 2)
                {
                    return 0;
                }
                else
                {
                    return base.Balance * base.Interest * (months - (this.Customer is Person ? 3 : 2));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The period in months could not be negative!");
            }
        }

        public override void Deposit(decimal amount)    //the loan could not have positive balance
        {
            if (base.Balance + amount <= 0)
            {
                base.Deposit(amount);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The deposited amount is greater than the loan!");
            }
        }
    }
}
