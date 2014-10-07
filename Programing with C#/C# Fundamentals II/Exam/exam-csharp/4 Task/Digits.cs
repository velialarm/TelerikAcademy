using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Digits
{
    static void Main(string[] args)
    {

        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        //read

        int n = int.Parse(Console.ReadLine());
        int[,] data = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] lineNums = Console.ReadLine().Split(); 
            for (int k = 0; k < n; k++)
            {
                data[i, k] = int.Parse(lineNums[k]);
            }
        }
        Console.WriteLine("Gadost maina. Reshi si go sam");
    }
}

