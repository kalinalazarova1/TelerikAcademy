using System;
using System.Text.RegularExpressions;

namespace MobilePhone
{
    public class Call
    {
        private DateTime? callStart = null;     //both date and time of the call are stored in one field of type DateTime
        private string dialedNumber = null;
        private int? duration = null;           //duration of the call in seconds

        public DateTime? CallStart 
        {
            get { return this.callStart; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The call date and time must always be specified!");
                }
                else
                {
                    this.callStart = value;
                }
            }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The dialed number must always be specified!");
                }
                else if (!Regex.IsMatch(value, "[+]?[0-9]+"))       //checks the validity of the phone number
                {
                    throw new ArgumentException("The specified number is not in a valid format!");
                }
                else
                {
                    this.dialedNumber = value;
                }
            }
        }

        public int? Duration
        {
            get { return this.duration; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The call duration must always be specified!");
                }
                else if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The call duration have to be greater than zero!");
                }
                else
                {
                    this.duration = value;
                }
            }
        }

        public Call(DateTime? callStart, string dialedNumber, int? duration) //all the fields in the Call class are mandatory
        {
            this.CallStart = callStart;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public override string ToString()
        {
            return string.Format("Date: {0}\tTime: {1}\tDuration: {2}\tNumber: {3}", this.CallStart.Value.Date.ToString("d"), this.CallStart.Value.TimeOfDay, this.Duration, this.DialedNumber);
        }
    }
}
