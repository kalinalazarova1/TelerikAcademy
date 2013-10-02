using System;

namespace HumanWorkerStudent
{
    public class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string first, string last, decimal salary, int workHours) : base(first, last)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHours;
        }

        private const int WorkDaysPerWeek = 5;

        public decimal MoneyPerHour()
        {
            return Math.Round(this.WeekSalary / (this.WorkHoursPerDay * WorkDaysPerWeek),2);
        }
    }
}
