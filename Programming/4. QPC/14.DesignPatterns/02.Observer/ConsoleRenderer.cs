namespace ClockWithEvent
{
    using System;

    public class ConsoleRenderer // ConcreteObserver class
    {
        public void Subscribe(Clock clock) // attach to Obeserver class
        {
            clock.TimeElapsed += this.RenderClock;      // connects method RenderClock() with the event TimeElapsed in class Clock
        }

        public void Unsubscribe(Clock clock) // detach from Obeserver class
        {
            clock.TimeElapsed -= this.RenderClock;      // disconnects method RenderClock() from the event TimeElapsed in class Clock
        }

        public void RenderClock(object sender, EventArgs args) // update()
        {
            Console.Clear();
            Console.WriteLine("Press a key to stop the clock.");
            Console.WriteLine("Time now: {0:00} : {1:00} : {2:00}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
    }
}
