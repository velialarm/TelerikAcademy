using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));

        var answers = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => int.Parse(Console.ReadLine()))
            .Select(answer => answer + 1)
            .ToArray();

        long total = 0;

        var colors = new int[1000002];

        foreach (int answer in answers)
        {
            colors[answer]++;

            if (colors[answer] >= answer)
            {
                total += answer;
                colors[answer] = 0;
            }
        }

        for (int i = 0; i < colors.Length; i++)
            if (colors[i] != 0)
                total += i;

        Console.WriteLine(total);
    }
}
