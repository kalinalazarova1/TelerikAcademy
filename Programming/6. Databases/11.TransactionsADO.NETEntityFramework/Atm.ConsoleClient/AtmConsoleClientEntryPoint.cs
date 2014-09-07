/* 1. Suppose you are creating a simple engine for an ATM machine. Create a new database "ATM" in SQL Server to hold the accounts of the card
 * holders and the balance (money) for each account. Add a new table CardAccounts with the following fields: 
 * Id (int)
 * CardNumber (char(10))
 * CardPIN (char(4))
 * CardCash (money)
Add a few sample records in the table. (see the Seed method in the Configuration class)
 * 
 * 2. Using transactions write a method which retrieves some money (for example $200) from certain account. The retrieval is successful when
 * the following sequence of sub-operations is completed successfully:
 * A query checks if the given CardPIN and CardNumber are valid.
 * The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
 * The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).
 * 
 * 3. Extend the project from the previous exercise and add a new table TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount)
 * containing information about all money retrievals on all accounts.
 * Modify the program logic so that it saves historical information (logs) in the new table after each successful money withdrawal.
 */

namespace Atm.ConsoleClient
{
    using System;
    using System.Linq;
    using Atm.Data;
    using Atm.Models;

    public class AtmConsoleClientEntryPoint
    {
        public static void Main()
        {
            var context = new AtmDataDbContext();
            using (context)
            {
                Console.WriteLine("All cards:");
                Console.WriteLine(string.Join(Environment.NewLine, context.CardAccounts.Select(c => new { Card = c.CardNumber, Balance = c.CardCash })));
                try
                {
                    var targetCard = new CardAccount() { CardNumber = "1234567892", CardPIN = 3434 };
                    WithdrawMoney(context, targetCard, 200m);
                    WithdrawMoney(context, targetCard, 2000m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void WithdrawMoney(AtmDataDbContext context, CardAccount card, decimal amount)
        {
            var transaction = context.Database.BeginTransaction();
            try
            {
                CardAccount targetCard;
                var found = context.CardAccounts.Where(c => c.CardNumber == card.CardNumber && c.CardPIN == card.CardPIN && c.CardCash >= amount);
                if (found.Count() == 0)
                {
                    throw new ApplicationException("Invalid card operation attempt.");
                }

                targetCard = found.First();
                Console.WriteLine("Initial balance: {0}", targetCard.CardCash);
                targetCard.CardCash -= amount;
                context.SaveChanges();
                context.TransactionsHistories.Add(new TransactionsHistory() 
                {
                    CardNumber = card.CardNumber,
                    TransactionDate = DateTime.Now,
                    Amount = amount 
                });
                context.SaveChanges();
                transaction.Commit();
                Console.WriteLine("Transaction completed successfully.");
                Console.WriteLine("Balance after the transaction: {0}", targetCard.CardCash);
            }
            catch (Exception e)
            {
                Console.WriteLine("Transaction not completed. Changes rolled back.");
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
        }
    }
}
