namespace Atm.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Atm.Data;
    using Atm.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AtmDataDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AtmDataDbContext context)
        {
            if (context.CardAccounts.Count() == 0)
            {
                var cards = new CardAccount[5];
                cards[0] = new CardAccount() { CardNumber = "1234567890", CardPIN = 1234, CardCash = 325.00m };
                cards[1] = new CardAccount() { CardNumber = "1234567891", CardPIN = 1212, CardCash = 3120.00m };
                cards[2] = new CardAccount() { CardNumber = "1234567892", CardPIN = 3434, CardCash = 1325.00m };
                cards[3] = new CardAccount() { CardNumber = "1234567893", CardPIN = 1221, CardCash = 475.00m };
                cards[4] = new CardAccount() { CardNumber = "1234567894", CardPIN = 3232, CardCash = 22.00m };
                foreach (var card in cards)
                {
                    context.CardAccounts.Add(card);
                }

                context.SaveChanges();
            }
        }
    }
}
