using System;
using System.Numerics;
using Wintellect.PowerCollections;

class Program
{
    static BigInteger Factorial(int n)
    {
        BigInteger result = 1;

        for (int i = 2; i <= n; i++)
            result *= i;

        return result;
    }

    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));

        var input = Console.ReadLine();

        var set = new MultiDictionary<char, int>(true);

        for (int i = 0; i < input.Length; i++)
            set[input[i]].Add(i);

        var result = Factorial(input.Length);

        foreach (var pair in set)
            result /= Factorial(pair.Value.Count);

        Console.WriteLine(result);
    }
}
