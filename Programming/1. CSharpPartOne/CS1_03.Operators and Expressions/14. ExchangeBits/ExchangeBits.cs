//Write a program that exchanges bits p,p+1,...,p+k-1 with bits q,q+1,...,q+k-1 of given 32-bit unsigned integer.

using System;

class ExchangeBits
{
    static void Main()
    {
        Console.WriteLine("Please enter an unsigned integer number:");
        uint i = uint.Parse(Console.ReadLine());  
        Console.WriteLine("Please enter the first sequence starting bit:");
        int p = Int32.Parse(Console.ReadLine());                  //first sequence start position
        Console.WriteLine("Please enter the second sequence starting bit:");
        int q = Int32.Parse(Console.ReadLine());                  //second sequence start position
        Console.WriteLine("Please enter the number of the bits in the sequence:");
        int k = Int32.Parse(Console.ReadLine());                  //sequence length in bits
        uint mask = 1;
        uint t;                     //temp result
        uint r;                     //result
        t = ((i >> p) ^ (i >> q)) & ((mask << k) - 1);//returns 1 in the mask for these bits in the sequences which are not equal and need to be swapped
        r = i ^ ((t << p) | (t << q));                //converts the bits in the original number which are 1 in the mask
        Console.WriteLine("Result: {0}", r);
    }
}