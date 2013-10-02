using System;
using System.Text;
using System.Collections.Generic;

namespace MobilePhone
{
    public class GSM
    {
        //private Battery battery = null; - this field is not included because there is an automatic property for it 
        //private Display display = null; - this field is not included because there is an automatic property for it
        private string model = null;
        private string manufacturer = null;
        private decimal? price = null;
        //private string owner = null; - this field is not included because there is an automatic property for it
        private List<Call> callHistory;

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            private set { this.callHistory = value; }
        }

        public void AddCall(Call currentCall)
        {
            this.CallHistory.Add(currentCall);
        }

        public List<Call> RemoveCall(int callIndex)
        {
            if (callIndex < 0 || callIndex >= this.CallHistory.Count)
            {
                throw new IndexOutOfRangeException("The specified call index must be positive and less than the call history count!");
            }
            else
            {
                this.CallHistory.RemoveAt(callIndex);
            }
            return this.CallHistory;
        }

        public List<Call> DeleteHistory()
        {
            this.CallHistory.Clear();
            return this.CallHistory;
        }

        public void PrintCallHistory()
        {
            Console.WriteLine(this);
            Console.WriteLine("Call History:");
            Console.WriteLine("_______________________________________________________________");
            foreach (Call call in this.CallHistory)
            {
                Console.WriteLine(call);
            }
            Console.WriteLine("_______________________________________________________________");
        }

        public decimal CalcTotalPriceCallHistory(decimal pricePerMinute)
        {
            decimal totalSum = 0;
            foreach (Call call in this.CallHistory) //the price is calculated for each started minute is due 0.37 BGN
            {        
                 totalSum += (decimal)(call.Duration / 60 + (call.Duration % 60 > 0 ? 1 : 0)) * pricePerMinute;
            }
            return Math.Round(totalSum, 2);
        }

        private static GSM iPhone4S = new GSM("IPhone4S", "Apple", 1000.00m, null, new Battery(200, 8, BatteryType.LiIon, "MXH1233"), new Display(3.5f, 16000000));

        public static GSM IPhone4S      //this static field is read-only
        {
            get { return iPhone4S; }
        }

        public GSM(string model, string manufacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null)
        {
            this.Model = model;             //this constructor is defined with default arguments which is alternative for making more constructors with diffenerent arguments
            this.Manufacturer = manufacturer; //model and manufacturer are mandatory fields
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new List<Call>();
        }

        public Battery Battery { get; private set; } //automatic property

        public Display Display { get; private set; } //automatic property

        public string Model 
        {
            get { return this.model; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("GSM model could not be empty!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("GSM manufacturer could not be empty!");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public decimal? Price
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The price must be greater than zero!");
                }
                else
                {
                    this.price = value;
                }
            }
            get { return this.price; } 
        }

        public string Owner { get; set; } //automatic property

        public override string ToString() //null feilds are printed with N/A
        {
            StringBuilder phoneInfo = new StringBuilder();
            phoneInfo.Append("--------------------------------------------------------------\n");
            phoneInfo.Append(string.Format("GSM: {0}\n", this.Manufacturer));
            phoneInfo.Append(string.Format("Model: {0}\n", this.Model));
            if (this.Battery != null)
            {
                phoneInfo.Append(this.Battery.ToString());
            }
            else
            {
                phoneInfo.Append("Battery: N/A\n");
            }
            if (this.Display != null)
            {
                phoneInfo.Append(this.Display.ToString());
            }
            else
            {
                phoneInfo.Append("Display: N/A\n");
            }
            if (this.Owner == null)
            {
                phoneInfo.Append(string.Format("Owner: N/A\n"));
            }
            else
            {
                phoneInfo.Append(string.Format("Owner: {0}\n", this.Owner));
            }
            if (this.Price == null)
            {
                phoneInfo.Append(string.Format("Price: N/A\n"));
            }
            else
            {
                phoneInfo.Append(string.Format("Price: {0} BGN\n", this.Price));
            }
            phoneInfo.Append("--------------------------------------------------------------\n");
            return phoneInfo.ToString();
        }

        public void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
