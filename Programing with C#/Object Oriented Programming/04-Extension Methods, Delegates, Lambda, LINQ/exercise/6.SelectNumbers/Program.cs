using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.SelectNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> num = Enumerable.Range(1, 100);

            Print(num.Where(n => n % 21 == 0));

            Print(
                from n in num
                where n % 21 == 0
                select n
            );
        }
        static void Print(IEnumerable list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

    }
}
