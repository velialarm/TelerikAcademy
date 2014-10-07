using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class TwoIsBetterThanOne
{
    static bool isPalindorm(long number) {
        string num = number.ToString();
        for (int i = 0; i < num.Length/2; i++)
        {
            if (num[i] != num[num.Length-i-1])
            {
                return false;
            }
        }
        return true;
    }

    static int FindLuckyNumbers(long loweBound, long upperBound) {
        //long max = (long)Math.Pow(10,18);
        //long max = 1000000000000000000;
        long max = upperBound; // 1000000000000000000
        int left = 0;
        var numbers = new List<long> { 3, 5 };
        int count = 0;
        while (left<numbers.Count)
        {
            int right = numbers.Count;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add((numbers[i] * 10) + 3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }
            left = right;
        }

        foreach (var num in numbers)
        {
            if (isPalindorm(num) &&
                num>= loweBound &&
                num<= upperBound)
            {
                count++;
            }
        }
        return count;
    }
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        string[] inp = Console.ReadLine().Split(' ');
        long lowerBound = long.Parse(inp[0]);
        long uppeBound = long.Parse(inp[1]);

        string[] listTokens = Console.ReadLine().Split(',');
        List<int> numbers = new List<int>();
        for (int i = 0; i < listTokens.Length; i++)
        {
            numbers.Add(int.Parse(listTokens[i]));
        }
        //List<int> numbers = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToList();
        int percent = int.Parse(Console.ReadLine());

        //first task
        int count = FindLuckyNumbers(lowerBound, uppeBound);
        Console.WriteLine(count);
        //second task
        int answerSecondTaks = FindAnswerSecondTask(numbers,percent);
        Console.WriteLine(answerSecondTaks);
    }

    private static int FindAnswerSecondTask(List<int> numbers, int percent)
    {
        numbers.Sort();
        for (int i = 0; i < numbers.Count; i++)
        {
            int countSmaller = 0;
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[i]>=numbers[j])
                {
                    countSmaller++;
                }
            }
            if (countSmaller >= (numbers.Count *(percent/100.0)))
            {
                return numbers[i];
            }
        }
        return numbers[numbers.Count - 1];
    }
}

