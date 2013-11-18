using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Bank
    {
        public List<Account> Accounts { get; set; }

        public Bank()
        {
            this.Accounts = new List<Account>();
        }

        public Bank(List<Account> accList)
        {
            this.Accounts = new List<Account>(accList);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var acc in this.Accounts)
            {
                output.Append(acc);
                output.Append('\n');
            }
            return output.ToString();
        }
    }
}
