using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter X: ");
            int x = int.Parse(Console.ReadLine());

            double sum = 1;
            double deli = 1;
            double fact = 1;

            for (int i = 1; i <= n; i++)
            {
                fact = 1;
                deli = 1;
                for (int k = 1; k <= i; k++)
                {
                    fact *= k;
                    deli *= x;
                    
                }
                
                sum += fact / (deli);
                Console.WriteLine("1!/Xn    -      {1} / {2} = {0}", sum, fact, deli);
            }
           
            Console.WriteLine("\n The sum S = 1 + 1!/X + 2!/X2 + ... + N!/XN is {0}", sum);
        }

    }
