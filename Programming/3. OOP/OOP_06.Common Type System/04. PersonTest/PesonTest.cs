//4.  Create a class Person with two fields – name and age. Age can be left unspecified 
//(may contain null value. Override ToString() to display the information of a person and
//if age is not specified – to say so. Write a program to test this functionality.

using System;

namespace PersonTest
{
    public static class PersonTest
    {
        static void Main()
        {
            Person someMan = new Person("Pesho",41);
            Console.WriteLine(someMan);
            Person someWoman = new Person("Anna");
            Console.WriteLine(someWoman);
        }
    }
}
