using System;

namespace Animals
{
    abstract public class Cat : Animal
    {
        protected Cat(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("The cat {0} said \"Miauuuu\"", base.Name);
        }
    }
}
