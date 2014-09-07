// 2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. 
// Write a testing class.
// 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

namespace _02.CustomersUtils
{
    using System;

    public static class CustomersUtilsTest
    {
        public static void Main()
        {
            // task 2:
            CustomersUtils.InsertNewCustomer("ABABA", "Fake Company", "Fake Name");
            CustomersUtils.InsertNewCustomer("AAAAA", "Fake Company", "Fake Name");
            CustomersUtils.ModifyCustomer("ABABA", "Trusted Company", "Trusted Name", null, null, null, null, null, null, null, null);
            CustomersUtils.RemoveCustomer("AAAAA");

            // task 3:
            var customers = CustomersUtils.GetOrdersShippedToAndMadeFromYear("Canada", 1997);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Result:");
            Console.WriteLine("-----------------------------");
            foreach (var customer in customers)
            {
                Console.WriteLine("{0}", customer);
            }

            // task 4:
            customers = CustomersUtils.GetWithSQLOrdersShippedToAndMadeFromYear("Canada", 1997);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Result with SQL query:");
            Console.WriteLine("-----------------------------");
            foreach (var customer in customers)
            {
                Console.WriteLine("{0}", customer);
            }
        }
    }
}
