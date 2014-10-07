using System;
using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that calculates for given N how many trailing zeros present at the end of the number N!.

            Console.WriteLine("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            BigInteger nFact = 1;

            for (int i = 1; i <= n; i++)
            {
                nFact *= i;
            }

            Console.WriteLine("{0}! = {1}", n, nFact);

            int zeroCounter = 0;

            while (true)
            {
                int result = n / 5;
                if (result != 0)
                {
                    zeroCounter = zeroCounter + result;
                    n = result;
                }
                else
                {
                    Console.WriteLine("Trailing zeros count: {0}", zeroCounter);
                    break;
                }
            }
        }
    }

