
	
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Formula_Bit1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] numbers = new byte[8];
            byte[][] bitRepresentation = new byte[8][];
            for (int i = 0; i < 8; ++i)
            {
                numbers[i] = byte.Parse(Console.ReadLine());
            }
 
            //creating the bit matrix
            for (byte i = 0; i < 8; ++i)
            {
                bitRepresentation[i] = getBitRepresentation(numbers[i]);
            }
 
            int way = 0; //0 for Sounth, 1 for west and 2 for North
            int trackLength = 0;
            int numberOfTurns = 0;
            int lastPointX = 0;
            int lastPointY = 0;
            int lastUpOrDownTurn = 0;
            bool isPlayable = true;
            while (isPlayable)
            {
                if (bitRepresentation[0][0] == 1)
                {
                    isPlayable = false;
                    break;
                }
                if (lastPointX == 7 && lastPointY == 7) break;
                if (way == 0)
                {
                    if (lastPointY + 1 <= 7 && lastPointX <= 7 && bitRepresentation[lastPointY + 1][lastPointX] == 0)
                    {
                        lastPointY += 1;
                        ++trackLength;
                        lastUpOrDownTurn = 0;
                    }
                    else if (lastPointY <= 7 && lastPointX + 1 <= 7 && bitRepresentation[lastPointY][lastPointX + 1] == 0)
                    {
                        lastPointX += 1;
                        way = 1;
 
                        ++trackLength;
                        ++numberOfTurns;
                    }
                    else if (lastPointX == 7 && lastPointY == 7) break;
                    else
                    {
                        isPlayable = false;
                    }
                }
                else if (way == 1)
                {
                    if (lastPointY <= 7 && lastPointX + 1 <= 7 && bitRepresentation[lastPointY][lastPointX + 1] == 0)
                    {
                        lastPointX += 1;
                        ++trackLength;
                    }
                    else if (lastPointY - 1 >= 0 && lastPointX <= 7 && lastUpOrDownTurn == 0 && bitRepresentation[lastPointY - 1][lastPointX] == 0)
                    {
                        lastPointY -= 1;
                        way = 2;
                        lastUpOrDownTurn = 2;
                        ++trackLength;
                        ++numberOfTurns;
                    }
                    else if (lastPointY + 1 <= 7 && lastPointX <= 7 && lastUpOrDownTurn == 2 && bitRepresentation[lastPointY + 1][lastPointX] == 0)
                    {
                        lastPointY += 1;
                        way = 0;
                        lastUpOrDownTurn = 0;
                        ++trackLength;
                        ++numberOfTurns;
                    }
                    else if (lastPointX == 7 && lastPointY == 7) break;
                    else
                    {
                        isPlayable = false;
                    }
                }
                else if (way == 2)
                {
                    if (lastPointY - 1 >= 0 && lastPointX <= 7 && bitRepresentation[lastPointY - 1][lastPointX] == 0)
                    {
                        lastPointY -= 1;
                        ++trackLength;
                    }
                    else if (lastPointX + 1 <= 7 && lastPointY <= 7 && bitRepresentation[lastPointY][lastPointX + 1] == 0)
                    {
                        lastUpOrDownTurn = 2;
                        lastPointX += 1;
                        ++trackLength;
                        ++numberOfTurns;
                        way = 1;
                    }
                    else if (lastPointX == 7 && lastPointY == 7) break;
                    else
                    {
                        isPlayable = false;
                    }
 
                }
 
            }
            if (isPlayable)
            {
                Console.WriteLine("{0} {1}", ++trackLength, numberOfTurns);
 
            }
            else
            {
                if (trackLength == 0)
                {
                    if (bitRepresentation[0][0] == 1)
                    {
                        Console.WriteLine("No {0}", 0);
                    }
                    else
                    {
                        Console.WriteLine("No {0}", 1);
                    }
 
                }
                else
                {
                    Console.WriteLine("No {0}", ++trackLength);
                }
 
            }
 
 
        }
        static byte[] getBitRepresentation(byte number)
        {
            byte[] result = new byte[8];
            for (byte i = 0; i < 8; ++i)
            {
                result[i] = (byte)getBit(number, i);
            }
            return result;
        }
        static byte getDecimalRepresentation(byte[] bits)
        {
            byte sum = 0;
            for (int i = 0; i < bits.Length; ++i)
            {
                sum += (byte)(bits[i] * Math.Pow(2, i));
            }
            return sum;
        }
        static byte getBit(byte number, byte position)
        {
            byte mask = (byte)(1U << position);
            byte result = (byte)((number & mask) >> position);
            return result;
        }
    }
}
