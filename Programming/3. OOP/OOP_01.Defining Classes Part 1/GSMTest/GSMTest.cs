using System;
using MobilePhone;

namespace MobilePhone
{
    public class GSMTest
    {
        //make some instances of the GSM class to test with different arguments for the constructor
        static void Main()
        {
            try
            {
                GSM[] mobilePhones = { new GSM("Galaxy Ace 7500S", "Samsung", 300.00m, "Petya Plamenova", new Battery(200, 8), new Display(3.5f, 16000000)),
                                        new GSM("Lumia 925", "Nokia" , 800.00m, "Stoyan Dobrev", new Battery(400, 17, BatteryType.LiIon, "MHX3320"), new Display(4.5f)),
                                        new GSM("DoNotBuyMe 330","GarbageMobiles")};
                foreach (GSM phone in mobilePhones)
                {
                    phone.PrintInfo();
                }
                GSM.IPhone4S.PrintInfo(); //the static field is accessible without making an instance of the GSM class
                GSM PanovGSM = GSM.IPhone4S; //the static field is used for initializing new GSM
                PanovGSM.Owner = "Petar Panov"; //an owner is added then
                PanovGSM.PrintInfo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
