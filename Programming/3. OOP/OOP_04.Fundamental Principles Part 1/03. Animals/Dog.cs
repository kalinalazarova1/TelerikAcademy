using System;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("The dog {0} said\"Bau-bau\"", base.Name);
        }
    }
}
