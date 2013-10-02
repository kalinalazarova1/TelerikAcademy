//7. Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Timer
{
    public class Timer
    {
        private Stopwatch startTime;

        public int TimeRunning 
        {
            get
            {
                return startTime.Elapsed.Seconds;
            }
        }

        public Timer()
        {
            startTime = new Stopwatch();
            startTime.Start();
        }

        public void Restart()
        {
            startTime.Restart();
        }

        public void PrintTime()
        {
            Console.WriteLine("The time is: {0}", DateTime.Now.ToLongTimeString());
        }

        public void Run(Action handler, int seconds)
        {
            while (true)
            {
                if (this.TimeRunning >= seconds)
                {
                    handler();
                }
            }
        }

        static void Main()
        {
            Timer newTime = new Timer();
            int t = 5;
            Action a = newTime.PrintTime;       //use of predefined delegate Action with return type void and no arguments
            a += newTime.Restart;               //attach a method to the delegate
            Console.WriteLine("You have to press Ctrl + C to stop the program.");
            newTime.Run(a, t);
        }
    }
}
