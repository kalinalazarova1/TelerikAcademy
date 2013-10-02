using System;


namespace MobilePhone
{
    public class Battery
    {
        private BatteryType? type = null;   //all the fields are nullable and private and are accessed by properties
        private string model = null;
        private int? hoursIdle = null;
        private int? hoursTalk = null;

        public BatteryType? Type
        {
            private set { this.type = value; }
            get { return this.type; }
        }

        public string Model
        {
            private set { this.model = value; }
            get { return this.model; }
        }

        public int? HoursIdle
        {
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The battery capacity could not be zero or less than zero!");
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
            get { return this.hoursIdle; }
        }

        public int? HoursTalk
        {
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The battery capacity could not be zero or less than zero!");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
            get { return this.hoursTalk; }
        }

        public Battery()
            : this(null, null, null, null)
        {
        }

        public Battery(int? hoursIdle, int? hoursTalk)  //each of the constructors are calling the constructor with maximum parameters
            : this(hoursIdle, hoursTalk, null, null)    //instead of calling each other which saves time
        {   
        }

        public Battery(int? hoursIdle, int? hoursTalk, BatteryType? type)
            : this(hoursIdle, hoursTalk, type, null)
        {
        }

        public Battery(int? hoursIdle, int? hoursTalk, BatteryType? type, string model)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
            this.Model = model;
        }

        public override string ToString()           //when a field is null it is printed as N/A not available
        {
            if (this.HoursIdle == null || this.HoursTalk == null)
            {
                return string.Format("Battery: N/A, Type: N/A, HoursIdle: N/A, HoursTalk: N/A\n");
            }
            else if (this.Type == null)
            {
                return string.Format("Battery: N/A, Type: N/A, HoursIdle: {0}, HoursTalk: {1}\n", this.HoursIdle, this.HoursTalk);
            }
            else if (this.Model == null)
            {
                return string.Format("Battery: N/A, Type: {0}, HoursIdle: {1}, HoursTalk: {2}\n", this.Type, this.HoursIdle, this.HoursTalk);
            }
            else
            {
                return string.Format("Battery: {0}, Type: {1}, HoursIdle: {2}, HoursTalk: {3}\n", this.Model, this.Type, this.HoursIdle, this.HoursTalk);
            }
        }
    }
}
