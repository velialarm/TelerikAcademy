using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            if(k<n)
            {
            Console.WriteLine("You number is invalid!");
            return;
            }
            int factk = 1;
            int factn = 1;
            for (int i = 1; i <= k; i++)
            {
                factk *= i;
                if( !((i <= n) && (k-n >= i)))
                {
                    factn *= i;    
                }
                Console.Write("N!*K!/(K-N)! = {0}",factk*factn); // 
                Console.WriteLine();
            }
        }
    }
