using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());

        string line = Console.ReadLine();
        char a = line[1];
        char b = line[3];
        Console.ReadLine();
        int n = int.Parse(Console.ReadLine());

        var triangle = new long[n + 1, n + 1];

        for (int row = 0; row <= n; row++)
        {
            triangle[row, 0] = 1;

            for (int col = 1; col < row; col++)
                triangle[row, col] = triangle[row - 1, col - 1] + triangle[row - 1, col];

            triangle[row, row] = 1;
        }

        for (int row = 0; row <= n; row++)
        {
            for (int col = 0; col <= row; col++)
                Console.Write(triangle[row, col]);
            
            Console.WriteLine();
        }

        var polynomial = new List<string>();

        for (int col = 0; col <= n; col++)
        {
            var str = new StringBuilder();

            if (triangle[n, col] != 1)
                str.Append(triangle[n, col]);

            if (n - col != 0)
                str.AppendFormat("({0}^{1})", a, n - col);

            if (col != 0)
                str.AppendFormat("({0}^{1})", b, col);

            polynomial.Add(str.ToString());
        }

        Console.WriteLine(string.Join("+", polynomial));
    }
}
