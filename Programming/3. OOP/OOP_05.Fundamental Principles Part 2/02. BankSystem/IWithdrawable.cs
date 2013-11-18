using System;

namespace BankSystem
{
    public interface IWithdrawable
    {
        void Withdraw(decimal amount);
    }
}
