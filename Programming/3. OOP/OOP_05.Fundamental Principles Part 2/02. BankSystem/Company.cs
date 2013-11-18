using System;
using System.Text.RegularExpressions;

namespace BankSystem
{
    public class Company : Customer
    {
        private string eIK;
        public string EIK
        {
            get
            {
                return this.eIK;
            }
            private set
            {
                if(Regex.IsMatch(value, @"[0-9]{9}"))
                {
                    this.eIK = value;
                }
                else
                {
                    throw new ArgumentException("The EIK is not valid!");
                }
            }
        }

        public Company(string name, string companyEIK)
            : base(name)
        {
            this.EIK = companyEIK;
        }
    }
}
