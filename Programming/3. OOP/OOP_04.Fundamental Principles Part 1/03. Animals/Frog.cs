using System;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("The frog {0} said\"Croak-croak\"", base.Name);
        }
    }
}
