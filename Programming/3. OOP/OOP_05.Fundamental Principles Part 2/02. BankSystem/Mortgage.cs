using System;

namespace BankSystem
{
    public class Mortgage : Account
    {
        public Mortgage(Customer cust, decimal interest, DateTime date, decimal saldo)
            : base(cust, interest, date, saldo)
        {
        }

        public Mortgage(Customer cust, decimal interest)
            : base(cust, interest)
        {
        }

        public override decimal CalcInterest(int months)
        {
            if (months >= 0)
            {
                if (this.Customer is Person && base.TotalMonthDuration <= 12)
                {
                    return 0;
                }
                else if(this.Customer is Company && base.TotalMonthDuration <= 6)
                {
                    return base.Balance * (base.Interest / 2) * months;
                }
                else if(this.Customer is Company && base.TotalMonthDuration > 6)
                {
                    return base.Balance * base.Interest * (months - 6) + base.Balance * (base.Interest / 2) * 6;
                }
                else
                {
                    return base.Balance * base.Interest * months;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The period in months could not be negative!");
            }
        }

        public override void Deposit(decimal amount)        //the mortgage could not have positive balance
        {
            if (base.Balance + amount <= 0)
            {
                base.Deposit(amount);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The deposited amount is greater than the mortgage!");
            }
        }
    }
}
