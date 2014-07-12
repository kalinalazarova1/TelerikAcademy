namespace ClockWithEvent
{
    internal class TimerTest
    {
        internal static void Main()
        {
            int interval = 1; // each 1 second the clock will be rendered
            Clock clock = new Clock(interval);
            ConsoleRenderer renderer = new ConsoleRenderer();
            renderer.Subscribe(clock);   
            clock.Run();
            renderer.Unsubscribe(clock);                   
        }
    }
}
