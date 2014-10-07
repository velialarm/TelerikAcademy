using System;
using System.Numerics;
    class Program
    {
        static void Main()
        {
            //Write a program to calculate n! for each n in the range [1..100]. 
            //Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

            BigInteger result = 1;

            Console.Write("Enter N to calculate n! :  ");
            int n = int.Parse(Console.ReadLine());

            result = Factoriel(result, n);

            Console.WriteLine("n! = {0}",result);
            //Console.WriteLine(result.ToString().Length);
        }

        private static BigInteger Factoriel(BigInteger result, int n)
        {
            for (int i = 2; i < n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
