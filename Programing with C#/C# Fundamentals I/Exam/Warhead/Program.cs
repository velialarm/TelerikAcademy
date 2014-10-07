using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[,] data = new int[16, 16];
        //recieve data
        for (int i = 0; i < 16; i++)
        {
            char[] line = Console.ReadLine().ToArray();
            for (int k = 0; k < 16; k++)
            {
                int x = Convert.ToInt32(new string(line[k], 1));
                data[i, k] = x;
            }
        }
        String command = Console.ReadLine();
        //Location
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());


        Console.WriteLine("print numbers");
        //print numbers
        for (int i = 0; i < 16; i++)
        {
            for (int k = 0; k < 16; k++)
            {
                Console.Write(data[i, k]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
