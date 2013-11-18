using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollection
{
    public class BitArray64 : IEnumerable<int>
    {
        //properties:
        public ulong Bits { get; set; }

        //constructors:
        public BitArray64(ulong number)
        {
            this.Bits = number;
        }

        public BitArray64()
            : this(0)
        {
        }

        //methods:
        public int this[int index]
	    {
		    get
            {
                return (int)((this.Bits & ((ulong)1 << index))>>index);
            }
		    private set
            {
                if (index < 0 && index >= 64)
                {
                    throw new IndexOutOfRangeException();
                }
                if (value == 1)
                {
                    this.Bits |= ((ulong)1 << index);
                }
                else if (value == 0)
                {
                    this.Bits &= (~((ulong)1 << index));
                }
                else
                {
                    throw new ArgumentException("Bit value must be 1 or 0!");
                }
            }
	    }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()     //this is explicit implementation throught interface
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            BitArray64 bitArray = obj as BitArray64;
            if (bitArray == null)
            {
                return false;
            }
            else
            {
                return this.Bits == bitArray.Bits;
            }
        }

        public override int GetHashCode()
        {
            return this.Bits.GetHashCode();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
    }
}
