using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static long Multiply(int start, int end)
    {
        long result = 1;

        for (int i = start; i <= end; i++)
            result *= i;

        return result;
    }

    static long Binom(int n, int k)
    {
        var nominator = Multiply(n - k + 1, n);
        var denominator = Multiply(1, k);

        return (nominator / denominator);
    }

    static long Sum(IEnumerable<int> numbers)
    {
        return numbers.Aggregate<int, long>(0, (current, t) => current + t);
    }

    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = input[0];
            var k = input[1];
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var result = Binom(n - 1, k) * Sum(numbers);
            Console.WriteLine(result);
        }
    }
}
