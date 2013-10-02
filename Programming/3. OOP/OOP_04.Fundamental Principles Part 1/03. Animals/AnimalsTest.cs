//3. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
//Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
//Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only
//female and tomcats can be only male. Each animal produces a specific sound. 
//Create arrays of different kinds of animals and calculate the average age of each kind of animal
//using a static method (you may use LINQ).

using System;
using System.Collections;
using System.Linq;

namespace Animals
{
    class AnimalsTest
    {
        static IEnumerable AverageAgeByKind(Animal[] arrAnimals)
        {
            return arrAnimals.GroupBy(a => a.GetType().Name).Select(k => new { AnimalType = k.Key, AverageAge = k.Average(a => a.Age)});
        }

        static void Main()
        {
            Animal[] zoo = { new Tomcat("Puffy", 3), new Kitten("Sisi", 2), new Tomcat("Gosho", 5), 
                             new Frog("Kvaki", 1, true), new Dog("Rex", 7, true), new Dog("Lassy", 4, false),
                             new Dog("Snoopy", 1, true), new Kitten("Unknown", 5)};
            foreach (var kind in AverageAgeByKind(zoo))
            {
                Console.WriteLine(kind);
            }
            foreach (Animal animal in zoo)
            {
                animal.MakeSound();
            }
        }
    }
}
