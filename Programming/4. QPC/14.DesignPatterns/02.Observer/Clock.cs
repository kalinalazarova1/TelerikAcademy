namespace ClockWithEvent
{
    using System;

    public delegate void TimeElapsedEventHandler(object sender, EventArgs args);

    public class Clock // ConcreteSubject class
    {
        public Clock(int interval)
        {
            this.TimeInterval = interval;
            this.StartTime = DateTime.Now;
        }

        public event TimeElapsedEventHandler TimeElapsed;

        public int TimeInterval { get; private set; } 

        public DateTime StartTime { get; private set; }

        public int TimeLeft             // dynamic property with no field behind it, returns the miliseconds left from the initial interval
        {
            get
            {
                return this.TimeInterval - (DateTime.Now - this.StartTime).Seconds;
            }
        }

        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                if (this.TimeLeft <= 0)
                {
                    this.OnTimeElapsed(EventArgs.Empty); // notify()
                    this.StartTime = DateTime.Now;
                }
            }
        }

        private void OnTimeElapsed(EventArgs args) // update() 
        {
            if (this.TimeElapsed != null)       
            {
                this.TimeElapsed(this, EventArgs.Empty);
            }
        }
    }
}
