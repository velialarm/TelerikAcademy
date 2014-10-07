using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        ulong a = uint.Parse(Console.ReadLine());
        //secret code symbol
        ulong b = uint.Parse(Console.ReadLine());
        ulong c = uint.Parse(Console.ReadLine());

        ulong r = 0;
        switch (b)
        {
            case 2:
                r = a % c;
                break;
            case 4:
                r = a + c;
                break;
            case 8:
                r = a * c;
                break;
            default:
                r = 0;
                break;
        }
        ulong result = 0;
        if (r % 4 == 0)
        {
            result = r / 4;
        }
        else
        {
            result = r % 4;
        }
        Console.WriteLine(result);
        Console.WriteLine(r);
    }
}
