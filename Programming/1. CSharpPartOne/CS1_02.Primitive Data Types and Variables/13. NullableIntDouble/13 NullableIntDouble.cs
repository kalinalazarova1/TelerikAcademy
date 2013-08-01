//Declare two nullable variables: integer and double, assign them with null literal
//print them to the console, add some numbers to them and see the result

using System;

class NullableIntDouble
{
    static void Main()
    {
        int? intVar = null;
        double? doubleVar = null;
        Console.WriteLine("{0} + 24 = {1}", intVar, intVar + 24);
        Console.WriteLine("{0} + 24.11 = {1}", doubleVar, doubleVar + 24.11);
        Console.WriteLine("{0} + {1} = {2}", intVar, null, intVar + null);
        Console.WriteLine("{0} + {1} = {2}", doubleVar, null, doubleVar + null);
    }
}
