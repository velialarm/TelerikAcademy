using System;
    class Program
    {
        static void Main()
        {
            //Write a program that finds all prime numbers in the range [1...10 000 000].
            //sieve of Erastoten

            int n = 10000000;
            int[] arr = new int[n];
            int pN = 0;


            int i = 2;
            while (i < n)
            {
                if (IsPrime(arr,i,pN))
                {
                    arr[pN] = i;
                    pN++;
                    Console.WriteLine(i);
                }
                i++;
            }
        }

        private static bool IsPrime(int[] arr, int n, int pN)
        {

            int i = 0;
            while ((i < pN) && (arr[i] * arr[i] <= n))
            {
                if (n % arr[i] == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
