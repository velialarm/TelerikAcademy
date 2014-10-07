using System;
    class Program
    {
        static void Main()
        {
            //Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
            
            //Намира всички комбинации на n елемента от k-ти клас

            Console.Write("Eneter number N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Eneter number K: ");
            int k = int.Parse(Console.ReadLine());

            int i=1;
            int after=0;
            int[] numbers = new int[n];

            Compination(n, k, i, after, numbers);
        }

        private static void Compination(int n, int k, int i, int after, int[] numbers)
        {
            if (i > k) 
            {
                return;
            }
            for (int j = after + 1; j <= n; j++)
            {
                numbers[i - 1] = j;
                if (i == k)
                {
                    PrintMe(i, numbers);
                    
                }
                Compination(n,k,i + 1, j,numbers);
            }
        }

        private static void PrintMe(int i, int[] numbers)
        {
            for (int x = 0; x < i; x++)
            {
                Console.Write("{0} ", numbers[x]);
            }
            Console.WriteLine();
        }
    }
