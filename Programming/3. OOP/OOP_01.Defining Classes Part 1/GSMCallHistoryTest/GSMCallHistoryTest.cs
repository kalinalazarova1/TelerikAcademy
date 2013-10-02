/* 1. Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics
 * (model, hours idle and hours talk) and display characteristics (size and number of colors).
 * 2. Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
 * Define several constructors for the defined classes that take different sets of arguments (the full information for the class or
 * part of it). Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.
 * 3. Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.
 * 4. Add a method in the GSM class for displaying all information about it. Try to override ToString().
 * 5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.
 * 6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
 * 7. Write a class GSMTest to test the GSM class:
 *      - Create an array of few instances of the GSM class.
 *      - Display the information about the GSMs in the array.
 *      - Display the information about the static property IPhone4S.
 * 8. Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).
 * 9. Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List.
 * 10. Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.
 * 11. Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and is provided
 * as a parameter.
 * 12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
         - Create an instance of the GSM class.
         - Add few calls.
         - Display the information about the calls.
         - Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
         - Remove the longest call from the history and calculate the total price again.
         - Finally clear the call history and print it.
 */

using System;
using System.Linq;

namespace MobilePhone
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            GSM MyGSM = new GSM("Galaxy S4", "Samsung",750.00m,"Slavi");
            // create an instance of the GSM class to test the call history functionality
            MyGSM.AddCall(new Call(new DateTime(2013, 09, 24, 10, 33, 00), "0887551432", 133));
            MyGSM.AddCall(new Call(new DateTime(2013, 09, 24, 11, 54, 10), "0886113432", 63));
            MyGSM.AddCall(new Call(new DateTime(2013, 09, 24, 23, 11, 23), "0886113432", 234));
            MyGSM.AddCall(new Call(new DateTime(2013, 09, 25, 07, 30, 03), "+359887551432", 73));
            MyGSM.AddCall(new Call(new DateTime(2013, 09, 25, 10, 04, 27), "+359897143223", 105));
            MyGSM.AddCall(new Call(new DateTime(2013, 09, 26, 15, 10, 55), "0878751030", 15));
            //add few calls and prints call history
            MyGSM.PrintCallHistory();
            Console.WriteLine();
            Console.WriteLine("The total price for the calls is: {0} BGN", MyGSM.CalcTotalPriceCallHistory(0.37m));
            //finds the longest call index
            int maxDuration = -1;
            int maxIndex = -1;
            for (int i = 0; i < MyGSM.CallHistory.Count; i++)
            {
                if (MyGSM.CallHistory[i].Duration > maxDuration)
                {
                    maxDuration = (int)MyGSM.CallHistory[i].Duration;
                    maxIndex = i;
                }
            }
            MyGSM.RemoveCall(maxIndex); //removes the call with the maximum duration and prints
            MyGSM.PrintCallHistory();
            Console.WriteLine("The total price for the calls is: {0} BGN", MyGSM.CalcTotalPriceCallHistory(0.37m));
            Console.WriteLine();
            MyGSM.DeleteHistory(); //clears all calls from the history and prints again
            MyGSM.PrintCallHistory();
        }
    }
}
