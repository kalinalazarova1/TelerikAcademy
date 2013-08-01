//Write a program that exchanges bits 3,4 and 5 with bits 24,25 and 26 of given 32-bit unsigned integer.

using System;

class ExchangeBits345
{
    static void Main()
    {
        int p = 3;                  //first sequence start position
        int q = 24;                 //second sequence start position
        int k = 3;                  //sequence length in bits
        uint i = 109051924;         //given unsigned int
        uint mask = 1;
        uint t;                     //temp result
        uint r;                     //result:41943092
        t = ((i >> p) ^ (i >> q)) & ((mask << k) - 1);//returns 1 in the mask for these bits in the sequences which are not equal and need to be swapped
        r = i ^ ((t << p) | (t << q));                //converts the bits in the original number which are 1 in the mask
        Console.WriteLine(r);
    }
}
