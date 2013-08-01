//12. Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array. 

using System;

class LettersIndex
{
    static void Main()
    {
        char[] letters = new char[26];
        for (int i = 0; i < 26; i++)
        {
            letters[i] = (char)('A' + i);
        }
        Console.WriteLine("Please input a word:");
        string input = Console.ReadLine();
        input = input.ToUpper();
        char[] word = input.ToCharArray();
        for (int i = 0; i < word.Length; i++)
        {
            Console.Write("{0} ", Array.BinarySearch(letters, word[i]));
        }
    }
}
