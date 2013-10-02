//8*. Read in MSDN about the keyword event in C# and how to publish events. Re-implement a class
//Timer that can execute a method once every t seconds using .NET events and
//following the best practices.

using System;

namespace TimerWithEvent
{
    class TimerTest
    {
        static void Main()
        {
            int seconds = 5;
            Timer test = new Timer(seconds); //starts the test timer and time measure
            Listener listener = new Listener(); //make an instance of class Listner in order to subscribe for the event TimeElapsed from class Timer
            Console.WriteLine("You have to press Ctrl + C to stop the program.");
            listener.Subscribe(test);   //when the event "time elapsed" happens the method PrintTimeNow() will be invoked because it is added to the event TimeElapsed
            test.Run();                 //this method checks every n seconds and invokes the event             
        }
    }
}
