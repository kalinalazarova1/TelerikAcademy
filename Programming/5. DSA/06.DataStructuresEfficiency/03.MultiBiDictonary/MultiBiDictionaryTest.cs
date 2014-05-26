// 3.Implement a class BiDictionary<K1,K2,T> that allows adding triples {key1, key2, value} and fast search
// by key1, key2 or by both key1 and key2. Note: multiple values can be stored for given key.

namespace _03.MultiBiDictonary
{
    using System;
    using System.Linq;

    public class MultiBiDictionaryTest
    {
        public static void Main()
        {
            var students = new MultiBiDictonary<string, string, int>(true);
            students.Add("Ivan", "Ivanov", 3);
            students.Add("Ivan", "Petrov", 2);
            students.Add("Ivan", "Hristov", 3);
            students.Add("Petar", "Ivanov", 4);
            students.Add("Petar", "Hristov", 4);
            students.Add("Petar", "Tzolov", 5);
            students.Add("Hristo", "Ivanov", 5);
            students.Add("Hristo", "Uzunov", 3);
            students.Add("Petar", "Ivanov", 6);

            var searchName = "Ivanov";
            Console.WriteLine("Average grade of {0}:", searchName);
            Console.WriteLine(students.FindSecondKey(searchName).Sum() * 1.0 / students.FindSecondKey(searchName).Count);

            searchName = "Petar";
            Console.WriteLine("Average grade of {0}:", searchName);
            Console.WriteLine(students.FindFirstKey(searchName).Sum() * 1.0 / students.FindFirstKey(searchName).Count);

            searchName = "Petar";
            var searchFamilyName = "Ivanov";
            Console.WriteLine("Average grade of {0} {1}:", searchName, searchFamilyName);
            Console.WriteLine(students.FindBothKeys(searchName, searchFamilyName).Sum() * 1.0 / students.FindBothKeys(searchName, searchFamilyName).Count);
        }
    }
}
