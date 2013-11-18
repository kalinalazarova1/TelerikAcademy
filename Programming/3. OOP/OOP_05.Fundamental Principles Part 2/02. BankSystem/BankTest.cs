/*2. A bank holds different types of accounts for its customers: deposit accounts, loan accounts and
 * mortgage accounts. Customers could be individuals or companies.
 * All accounts have customer, balance and interest rate (monthly based). Deposit accounts are allowed
 * to deposit and with draw money. Loan and mortgage accounts can only deposit money.
 * All accounts can calculate their interest amount for a given period (in months). In the common case 
 * its is calculated as follows: number_of_months * interest_rate.
 * Loan accounts have no interest for the first 3 months if are held by individuals and for the first
 * 2 months if are held by a company.
 * Deposit accounts have no interest if their balance is positive and less than 1000.
 * Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the
 * first 6 months for individuals.
 * Your task is to write a program to model the bank system by classes and interfaces. You should 
 * identify the classes, interfaces, base classes and abstract actions and implement the calculation
 * of the interest functionality through overridden methods.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem
{
    public static class BankTest
    {
        static void Main()
        {
            try
            {
                Bank myBank = new Bank();
                Random ranGen = new Random();
                for (int i = 0; i < 3; i++)
                {
                    myBank.Accounts.Add(new Loan(new Company("CheatInvestments Ltd", ranGen.Next(100000000, 1000000000).ToString()), 10m / 100, new DateTime(ranGen.Next(2012, 2014), ranGen.Next(1, 13), ranGen.Next(1, 29)), ranGen.Next(-10000, -1000)));
                    myBank.Accounts.Add(new Mortgage(new Person("Petar Penev", string.Format("{0}{1}", ranGen.Next(100000000, 1000000000), ranGen.Next(0, 10))), 10m / 100, new DateTime(2012, ranGen.Next(1, 13), ranGen.Next(1, 29)), ranGen.Next(-10000, -1000)));
                    myBank.Accounts.Add(new Deposit(new Company("GiveMeYourMoney Ltd", ranGen.Next(100000000, 1000000000).ToString()), 10m / 100, new DateTime(2012, ranGen.Next(1, 13), ranGen.Next(1, 29)), ranGen.Next(0, 10000)));
                }
                Console.WriteLine("My Bank:");
                Console.WriteLine(myBank);

                foreach (var account in myBank.Accounts)
                {
                    account.Deposit(ranGen.Next(100, 1001));
                }
                Console.WriteLine("We deposite some money:");
                Console.WriteLine(myBank);

                foreach (Deposit deposit in myBank.Accounts.Where(x => x is Deposit))
                {
                    deposit.Withdraw(ranGen.Next(5, 101));
                }
                Console.WriteLine("We withdraw some money:");
                Console.WriteLine(myBank);

                Console.WriteLine("We calculate some interests:");
                foreach (var account in myBank.Accounts)
                {
                    int months = ranGen.Next(1, 12);
                    Console.WriteLine();
                    Console.WriteLine("Calculated interest: {0} for months: {1}", account.CalcInterest(months), months);
                    account.Balance += account.CalcInterest(months);
                    Console.WriteLine("New saldo:");
                    Console.WriteLine(account);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
