using System;

namespace TimerWithEvent
{
    public class Listener
    {
        public void Subscribe(Timer timer)
        {
            timer.TimeElapsed += PrintTimeNow;      //connects method PrintTimeNow() with the event TimeElapsed from class Timer
        }

        public void PrintTimeNow(object sender, EventArgs args)
        {
            Console.WriteLine("The time is: {0}", DateTime.Now.ToLongTimeString());
        }
    }
}
