using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitArray64:IEnumerable<int>
{
    private ulong value;

    public BitArray64(ulong num)
    {
        this.value = num;
    }

    public IEnumerator<int> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        return this.value.Equals(obj) ? true : false;
    }

    public override int GetHashCode()
    {
        throw new System.NotImplementedException();
    }

    public static bool operator ==(BitArray64 val1, ulong val2)
    {
        return val1.Equals(val2);
    }

    public static bool operator !=(BitArray64 val1, ulong val2)
    {
        return !(val1 == val2);
    }
}

