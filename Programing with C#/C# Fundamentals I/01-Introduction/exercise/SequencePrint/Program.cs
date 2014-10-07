using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencePrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string descr = "Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...";
            Console.WriteLine(descr);
            Console.WriteLine();
            for (int i = 0; i <= 10; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write("-{0}, ",i);
                }
                else {
                    Console.Write("{0}, ", i);
                }
            }
            Console.WriteLine();
        }
    }
}
