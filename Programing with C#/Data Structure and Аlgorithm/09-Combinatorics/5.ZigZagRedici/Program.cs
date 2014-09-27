using System;
using System.Linq;
using System.Diagnostics;

class Program
{
    static int[] numbers = null;

    static bool[] used = null;

    static int result = 0;

    static void Variation(int i, int previous, int direction)
    {
        if (i == numbers.Length)
        {
            result++;

            Debug.WriteLine(string.Join(" ", numbers));

            return;
        }

        for (int j = previous + direction; 0 <= j && j < used.Length; j += direction)
        {
            if (used[j]) continue;

            numbers[i] = j;

            used[j] = true;
            Variation(i + 1, j, -1 * direction);
            used[j] = false;
        }
    }

    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());

        var input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        numbers = new int[input[1]]; // 2
        used = new bool[input[0]]; // 4

        Variation(0, -1, 1);

        Console.WriteLine(result);
    }
}
