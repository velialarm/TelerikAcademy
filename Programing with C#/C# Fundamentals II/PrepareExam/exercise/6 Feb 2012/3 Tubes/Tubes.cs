using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        List<int> sizes = new List<int>();
        int sumLengTubes = 0;
        for (int i = 0; i < n; i++)
        {
            int tube = int.Parse(Console.ReadLine());
            sizes.Add(tube);
            sumLengTubes+= tube;
        }
        int result = sumLengTubes / m;
        Console.WriteLine(result);
    }
}

