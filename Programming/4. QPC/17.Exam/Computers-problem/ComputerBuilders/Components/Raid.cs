namespace ComputersBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Raid : IHardDrive
    {
        private ICollection<IHardDrive> raidArray;
        private int capacity;

        public Raid(int capacity, int hardDrivesInRaid)
        {
            this.capacity = capacity;
            this.raidArray = new List<IHardDrive>();
        }

        public Raid(int capacity, int hardDrivesInRaid, ICollection<IHardDrive> hardDrives)
            : this(capacity, hardDrivesInRaid)
        {
            foreach (var drive in hardDrives)
            {
                this.raidArray.Add(drive);
            }
        }

        public int Capacity
        {
            get
            {
                if (!this.raidArray.Any())
                {
                    return 0;
                }

                return this.raidArray.First().Capacity;
            }
        }

        public void SaveData(int address, string newData)
        {
            foreach (var hardDrive in this.raidArray)
            {
                hardDrive.SaveData(address, newData);
            }
        }

        public string LoadData(int address)
        {
            if (!this.raidArray.Any())
            {
                throw new ArgumentException("No hard drive in the RAID array!");
            }

            return this.raidArray.First().LoadData(address);
        }
    }
}
