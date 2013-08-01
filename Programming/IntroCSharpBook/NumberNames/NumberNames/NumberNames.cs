using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberNames
{
    class NumberNames
    {
        static void Main(string[] args)
        {
            string hundreds=null, decimals=null, units= null;
            int number = 1000;
            do
            {
                Console.WriteLine("Моля въведете число в диапазона от 0 до 999:");
                while (Int32.TryParse(Console.ReadLine(), out number) == false)
                {
                    Console.WriteLine("Моля въведете число в диапазона от 0 до 999:");
                }
            }
            while ((number < 0) || (number > 999));
            switch (number/100)
            {
                case 0: break;
                case 1: hundreds="сто "; number=number-100; break;
                case 2: hundreds="двеста "; number=number-200; break;
                case 3: hundreds="триста "; number=number-300; break;
                case 4: hundreds="четиристотин "; number=number-400; break;
                case 5: hundreds="петстотин "; number=number-500; break;
                case 6: hundreds="шестстотин "; number=number-600; break;
                case 7: hundreds="седемстотин "; number=number-700; break;
                case 8: hundreds="осемстотин "; number=number-800; break;
                case 9: hundreds="деветстотин "; number=number-900; break;
            }
            switch (number/10)
            {
                case 0: break;
                case 1: switch (number)
                {
                    case 10: units = "десет "; break;
                    case 11: units = "единадесет "; break;
                    case 12: units="дванадесет "; break;
                    case 13: units="тринадесет "; break;
                    case 14: units="четиринадесет "; break;
                    case 15: units="петнадесет "; break;
                    case 16: units="шестнадесет "; break;
                    case 17: units="седемнадесет "; break;
                    case 18: units="осемнадесет "; break;
                    case 19: units="деветнадесет "; break;
                }; break;
                case 2: decimals="двадесет "; number=number-20; break;
                case 3: decimals="тридесет "; number=number-30; break;
                case 4: decimals="четиридесет "; number=number-40; break;
                case 5: decimals="петдесет "; number=number-50; break;
                case 6: decimals="шестдесет "; number=number-60; break;
                case 7: decimals="седемдесет "; number=number-70; break;
                case 8: decimals="осемдесет "; number=number-80; break;
                case 9: decimals="деветдесет "; number=number-90; break;
            }
            switch (number)
            {
                case 0: if((hundreds==null) && (decimals==null)) 
                   {
                    units="нула";
                    }; break;
                case 1: units="едно"; break;
                case 2: units="две"; break;
                case 3: units="три"; break;
                case 4: units="четири"; break;
                case 5: units="пет"; break;
                case 6: units="шест"; break;
                case 7: units="седем"; break;
                case 8: units="осем"; break;
                case 9: units="девет"; break;
            }
            if(hundreds==null)
            {
                if(decimals==null)
                {
                    Console.WriteLine("Словом: " + units);
                }
                else if(units==null)
                    {
                        Console.WriteLine("Словом: " + decimals);
                    }
                    else
                    {
                        Console.WriteLine("Словом: " + decimals + "и " + units);
                    }
             }
            else
            {
                if(decimals==null)
                {
                    if(units==null)
                    {
                    Console.WriteLine("Словом: " + hundreds);
                    }
                    else
                    {
                    Console.WriteLine("Словом: " + hundreds + "и " + units);
                    }
                }
                else if(units==null)
                    {
                        Console.WriteLine("Словом: " + hundreds + "и " + decimals);
                    }
                    else
                    {
                        Console.WriteLine("Словом: " + hundreds + decimals + "и " + units);
                    }
            }

        }
    }
}
