using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

class Zerg
{
    private static string[] numbers = new string[]{"Rawr","Rrrr","Hsst","Ssst","Grrr","Rarr","Mrrr","Psst","Uaah","Uaha","Zzzz","Bauu","Djav","Myau","Gruh"};
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        //read
        string input = Console.ReadLine();
        int index = 0;
        List<int> listNum = new List<int>();
        while (true)
        {
            if (index >= input.Length)
            {
                break;
            }
            string num = input.Substring(index, 4);
            int numValue = FindValue(num);
            listNum.Add(numValue);
            index += 4;
        }

        //calculate
        BigInteger sum = 0; ;
        for (int i = 0; i < listNum.Count; i++)
        {
            sum += listNum[i] * BigInteger.Pow(15,listNum.Count-i-1);
        }
        Console.WriteLine(sum);
    }

    private static int FindValue(string num)
    {
        for (int i = 0; i < 15; i++)
        {
            if (num == numbers[i])
            {
                return i;
            }
        }
        return -1;
    }
}

