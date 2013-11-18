using System;
using System.Text.RegularExpressions;

namespace BankSystem
{
    public class Person : Customer
    {
        private string eGN;
        public string EGN
        {
            get
            {
                return this.eGN;
            }
            private set
            {
                if (Regex.IsMatch(value, @"[0-9]{10}"))
                {
                    this.eGN = value;
                }
                else
                {
                    throw new ArgumentException("The EGN is not valid!");
                }
            }
        }

        public Person(string name, string custEGN) : base(name)
        {
            this.EGN = custEGN;
        }
    }
}
