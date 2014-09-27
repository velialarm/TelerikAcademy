using System;
using System.Linq;
using System.Collections.Generic;

class Permutator<T>
{
    private readonly IList<T> elements = null;
    private readonly IList<bool> used = null;
    private readonly IList<int> indices = null;

    private Action<IList<T>> action = null;

    public Permutator(IList<T> elements)
    {
        this.elements = elements;

        this.used = new bool[elements.Count];
        this.indices = new int[elements.Count];
    }

    public void Permutation(Action<IList<T>> action)
    {
        this.action = action;

        Permutation(0);
    }

    private void Permutation(int i)
    {
        if (i == indices.Count)
        {
            action(indices.Select(x => elements[x]).ToArray());
            return;
        }

        for (int j = 0; j < indices.Count; j++)
        {
            if (used[j]) continue;

            indices[i] = j;

            used[j] = true;
            Permutation(i + 1);
            used[j] = false;
        }
    }
}

class Program
{
    static int CountDivisors(int n)
    {
        int result = 0;

        for (int i = 1; i <= n; i++)
            if (n % i == 0)
                result++;

        return result;
    }

    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));

        var numbers = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine())
            .ToArray();

        int minNumber = -1;
        int minDivisors = int.MaxValue;

        new Permutator<string>(numbers).Permutation(currentPermutation =>
        {
            int currentNumber = int.Parse(string.Concat(currentPermutation));

            int currentDivisors = CountDivisors(currentNumber);

            if (currentDivisors < minDivisors ||
                currentDivisors == minDivisors && currentNumber < minNumber)
            {
                minDivisors = currentDivisors;
                minNumber = currentNumber;
            }

#if DEBUG
            Console.WriteLine("{0} {1}", currentNumber, currentDivisors);
#endif
        });

        Console.WriteLine(minNumber);
    }
}
