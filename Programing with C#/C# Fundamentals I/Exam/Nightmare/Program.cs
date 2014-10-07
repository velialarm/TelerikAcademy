using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        char[] line = Console.ReadLine().ToArray();

        int lenghtLine = line.Length;
        int count = 0;
        int sum = 0;
        for (int i = 0; i < lenghtLine; i++)
        {
            try
            {
                int x = Convert.ToInt32(new string(line[i], 1));
                if (i % 2 != 0)
                {
                    count++;
                    sum += x;
                }
            }
            catch (Exception)
            {
                //it is not number 
            }

        }
        Console.WriteLine("{0} {1}", count, sum);
    }
}

