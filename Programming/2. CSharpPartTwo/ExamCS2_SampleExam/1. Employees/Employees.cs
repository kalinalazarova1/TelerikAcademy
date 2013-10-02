using System;
using System.Collections.Generic;
using System.Linq;

class Employees
{
    struct Employee
    {
        public string firstName;
        public string lastName;
        public int value;
    }

    static void Main()
    {
        Dictionary<string, int> positions = new Dictionary<string, int>();
        List<Employee> personnel = new List<Employee>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            if(!positions.ContainsKey(input[0].Trim()))
            {
            positions.Add(input[0].Trim(), int.Parse(input[1]));
            }
        }
        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            Employee single = new Employee();
            string[] name = input[0].Trim().Split(' ');
            single.firstName = name[0];
            single.lastName = name[1];
            int positionValue;
            positions.TryGetValue(input[1].Trim(), out positionValue);
            single.value = positionValue;
            personnel.Add(single);
        }
        foreach (Employee person in personnel.OrderByDescending(p => p.value).ThenBy(p => p.lastName).ThenBy(p => p.firstName))
        {
            Console.WriteLine("{0} {1}", person.firstName, person.lastName);
        }
    }
}
