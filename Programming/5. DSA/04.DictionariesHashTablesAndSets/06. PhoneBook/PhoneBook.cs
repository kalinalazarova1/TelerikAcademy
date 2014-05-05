using System;
using System.Collections.Generic;
using System.Linq;

public class PhoneBook
{
    private Dictionary<string, HashSet<PhoneRecord>> records;
    private Dictionary<string, HashSet<string>> names;

    public PhoneBook()
    {
        this.records = new Dictionary<string, HashSet<PhoneRecord>>();
        this.names = new Dictionary<string, HashSet<string>>();
    }

    public void Add(PhoneRecord record)
    {
        if (!this.records.ContainsKey(record.Name))
        {
            this.records[record.Name] = new HashSet<PhoneRecord>();
        }

        this.records[record.Name].Add(record);

        if (!this.names.ContainsKey(record.Name))
        {
            this.names[record.Name] = new HashSet<string>();
        }

        this.names[record.Name].Add(record.Name);

        foreach (var item in record.Name.Split(' '))
        {
            if (!this.names.ContainsKey(item))
            {
                this.names[item] = new HashSet<string>();
            }

            this.names[item].Add(record.Name);
        }
    }

    public IEnumerable<PhoneRecord> Find(string name)
    {
        if (this.names.ContainsKey(name))
        {
            var result = new List<PhoneRecord>();
            foreach (var fullName in this.names[name])
            {
                result.AddRange(this.records[fullName]);
            }

            return result;
        }

        return null;
    }

    public IEnumerable<PhoneRecord> Find(string name, string town)
    {
        if (this.names.ContainsKey(name))
        {
            var result = new List<PhoneRecord>();
            foreach (var fullName in this.names[name])
            {
                result.AddRange(this.records[fullName].Where(r => r.Town == town));
            }

            return result;
        }

        return null;
    }
}
