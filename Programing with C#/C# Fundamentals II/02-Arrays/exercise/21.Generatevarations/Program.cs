using System;
    class Program
    {
        static void Main()
        {
            //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 

            Console.Write("Eneter number N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Eneter number K: ");
            int k = int.Parse(Console.ReadLine());

            int[] taken = new int[n];
            


            VariateGenerator(n, k, taken, 0);
        }

        private static void VariateGenerator(int n, int k, int[] taken, int i)
        {
            if (i >= k)
            {
                PrintMe(taken, i);
                return;
            }
            for (int j = 0; j < n; j++)
            {
                taken[i] = j;
                VariateGenerator(n,k,taken,i + 1);
            }
        }

        private static void PrintMe(int[] taken, int i)
        {
            for (int x = 0; x < i ; x++)
            {
                Console.Write("{0} ", taken[x] + 1);
            }
            Console.WriteLine();
        }
    }
