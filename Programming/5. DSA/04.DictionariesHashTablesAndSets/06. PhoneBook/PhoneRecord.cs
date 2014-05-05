using System;
using System.Collections.Generic;
using System.Linq;

public class PhoneRecord
{
    public PhoneRecord(string[] data)
    {
        this.Name = data[0].Trim();
        this.Town = data[1].Trim();
        this.Phone = data[2].Trim();
    }

    public string Name { get; set; }

    public string Town { get; set; }

    public string Phone { get; set; }

    public override bool Equals(object obj)
    {
        var other = obj as PhoneRecord;

        if (other == null)
        {
            return false;
        }

        if (other.Name == this.Name && other.Town == this.Town && other.Phone == this.Phone)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() ^ this.Town.GetHashCode() ^ this.Phone.GetHashCode();
    }

    public override string ToString()
    {
        return this.Name + " | " + this.Town + " | " + this.Phone;
    }
}
