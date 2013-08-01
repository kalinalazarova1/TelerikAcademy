//Declare two string variables and assign them with "Hello"and "World" Then create an object
// variable and assign it with concantenation of the first two and interval between them. 
//Declare third string variable and assign it with the value of the object variable

using System;

class HelloWorld
{
    static void Main()
    {
        string strHello = "Hello";
        string strWorld = "World";
        object greeting = strHello + " " + strWorld;
        string phrase = (string)greeting;
        Console.WriteLine(greeting);
    }
}
