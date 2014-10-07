using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that calculates N!/K! for given N and K (1<K<N).

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());

            int del = k - n;
            double sum = 1.0; 
            for (int i = 1; i <= del; i++)
			{
                sum *= i + n;
                // Console.WriteLine("For {2} Loops N!/k! = {1}",i+n,1/sum,i);
                

			}
            Console.WriteLine("N!/k! = {0}", 1 / sum);
            
        }
    }
