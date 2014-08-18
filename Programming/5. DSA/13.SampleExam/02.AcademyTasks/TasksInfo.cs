namespace _02.AcademyTasks
{
    public class TasksInfo
    {
        public TasksInfo(int min, int max, int task)
        {
            this.Min = min;
            this.Max = max;
            this.CurrnetTask = task;
        }

        public int Min { get; set; }

        public int Max { get; set; }

        public int CurrnetTask { get; set; }
    }
}
