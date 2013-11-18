using System;

namespace InvalidRangeException
{
    public class InvalidRangeException<T> : ApplicationException where T : struct, IComparable<T>
    {
        public string Message { get; set; }
        public T StartRange { get; set; }
        public T EndRange { get; set; }

        public InvalidRangeException(string message, T start, T end)
        {
            if (start.CompareTo(end) <= 0)
            {
                this.StartRange = start;
                this.EndRange = end;
                this.Message = message;
            }
            else
            {
                throw new ArgumentException("The start of the range must be less or equal to end of the range!");
            }
        }

    }
}
