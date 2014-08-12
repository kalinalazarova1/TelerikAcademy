namespace ComputersBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDrive : IHardDrive
    {
        private int numberDrivesInRaid;
        private List<HardDrive> hardDrivesRaid;
        private int capacity;
        private Dictionary<int, string> data;

        internal HardDrive(int capacity, int hardDrivesInRaid) :
            this(capacity, hardDrivesInRaid, new List<HardDrive>())
        {
        }

        internal HardDrive(int capacity, int hardDrivesInRaid, List<HardDrive> hardDrives)
        {
            this.numberDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
            this.hardDrivesRaid = hardDrives;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public string LoadData(int address)
        { 
            return this.data[address];
        }
    }
}
