using System;

namespace TimerWithEvent
{
    public delegate void TimeElapsedEventHandler(object sender, EventArgs args);

    public class Timer
    {
        public event TimeElapsedEventHandler TimeElapsed;

        public int TimeInterval { get; private set; }

        public DateTime StartTime { get; private set; }

        public int TimeLeft             //dynamic property with no field behind it, returns the seconds left from the initial interval
        {
            get
            {
                return this.TimeInterval - (DateTime.Now - this.StartTime).Seconds;
            }
        }

        public Timer(int interval)
        {
            this.TimeInterval = interval;
            this.StartTime = DateTime.Now;
        }

        private void OnTimeElapsed(EventArgs args) //it is private because the event could only be invoked in the class it is declared
        {
            if (TimeElapsed != null)       //if a method is connected to the event TimeElapsed it will be invoked
            {
                this.TimeElapsed(this, EventArgs.Empty);
            }
        }

        public void Run()
        {
            while (true)
            {
                if (this.TimeLeft <= 0)
                {
                    OnTimeElapsed(EventArgs.Empty);
                    this.StartTime = DateTime.Now;
                }
            }
        }

    }
}
