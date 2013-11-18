using System;

namespace BankSystem
{
    public abstract class Customer
    {
        private static int idGenerator = 1;
        public string Name { get; set; }
        public string ID { get; private set; }

        public Customer(string name)
        {
            this.Name = name;
            this.ID = string.Format("{0:000000}", idGenerator);
            idGenerator++;
        }

        public override string ToString()
        {
            return this.GetType().Name + ' ' + this.Name;
        }
    }
}
